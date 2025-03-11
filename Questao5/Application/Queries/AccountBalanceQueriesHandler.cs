using Questao5.Core.Notifications.Interfaces;
using Questao5.Core.Resourcers;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Questao5.Domain.Interfaces;

namespace Questao5.Application.Queries
{
    public class AccountBalanceQueriesHandler : BaseHandler, IAccountBalanceQueriesHandler
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly IMovimentRepository _movimentoRepository;

        public AccountBalanceQueriesHandler(IContaCorrenteRepository contaCorrenteRepository,
            IMovimentRepository movimentoRepository,
            IDomainNotifier domainNotifier) : base(domainNotifier)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
            _movimentoRepository = movimentoRepository;
        }

        private decimal CalculateBalance(IEnumerable<Movimento> moviments)
        {
            var credit = moviments.Where(e => e.TipoMovimento == ETipoMovimento.Credito).Sum(e => e.Valor);
            var debit = moviments.Where(e => e.TipoMovimento == ETipoMovimento.Debito).Sum(e => e.Valor);

            return (credit - debit);
        }

        public async Task<object?> Handle(string accountId)
        {
            var account = await _contaCorrenteRepository.GetContaCorrenteByIdAsync(accountId);
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

            var moviments = await _movimentoRepository.GetMovimentByIdAccountAsync(accountId);

            return new
            {
                numeroConta = account.Numero,
                nomeTitular = account.Nome,
                dataHora = DateTime.Now,
                Saldo = CalculateBalance(moviments)
            };
        }
    }
}
