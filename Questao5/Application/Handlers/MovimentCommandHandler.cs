using MediatR;
using Newtonsoft.Json;
using Questao5.Application.Commands.Requests;
using Questao5.Core.Mediator;
using Questao5.Core.Notifications.Interfaces;
using Questao5.Core.Resourcers;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Questao5.Domain.Interfaces;

namespace Questao5.Application.Handlers
{
    public class MovimentCommandHandler : BaseHandler,
        IRequestHandler<MoveAccountCommand, object?>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly IMovimentRepository _movimentoRepository;

        public MovimentCommandHandler(IMediatorHandler mediatorHandler,
            IContaCorrenteRepository contaCorrenteRepository,
            IMovimentRepository movimentoRepository,
            IDomainNotifier domainNotifier) : base(domainNotifier)
        {
            _mediatorHandler = mediatorHandler;
            _contaCorrenteRepository = contaCorrenteRepository;
            _movimentoRepository = movimentoRepository;
        }

        public async Task<object?> Handle(MoveAccountCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                Notifier(message.ValidationResult!);

                return null;
            }

            var account = await _contaCorrenteRepository.GetContaCorrenteByIdAsync(message.AccountId!);
            if (account is null)
            {
                Notifier(Errors.InvalidAccount, "INVALID_ACCOUNT");
                return null;
            }

            if (account.Ativo != EAtivo.Ativo)
            {
                Notifier(Errors.InactiveAccount, "INACTIVE_ACCOUNT");
                return null;
            }

            var moviment = new Movimento(Guid.NewGuid().ToString(), account!.Id, DateTime.Now, message.TypeMovement!.ToUpper(), (decimal)message.Value!);

            if (!await _movimentoRepository.AddMovimentAsync(moviment))
            {
                Notifier(Errors.DataBaseError);
                return null;
            }

            var result = new
            {
                id = moviment.Id,
            };

            var request = JsonConvert.SerializeObject(message);            
            var response = JsonConvert.SerializeObject(result);
            await _mediatorHandler.PublishEvent(new Idempotencia(Guid.NewGuid().ToString(), request, response));
            
            return result;
        }
    }
}
