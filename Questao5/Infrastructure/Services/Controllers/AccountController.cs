using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Queries;
using Questao5.Core.Mediator;
using Questao5.Core.Notifications.Interfaces;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("conta-corrente")]
    public class AccountController : BaseController
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMediatorHandler _mediatorHandler;        
        private readonly IAccountBalanceQueriesHandler _accountBalanceQueriesHandler;

        public AccountController(ILogger<AccountController> logger,
            IMediatorHandler mediatorHandler,            
            IAccountBalanceQueriesHandler accountBalanceQueriesHandler,
            IDomainNotifier notifier) : base(notifier)
        {
            _logger = logger;
            _mediatorHandler = mediatorHandler;            
            _accountBalanceQueriesHandler = accountBalanceQueriesHandler;
        }

        [HttpGet("saldo/{idConta}")]
        public async Task<IActionResult> GetMoviment(string idConta)
        {
            return CustomResponse(await _accountBalanceQueriesHandler.Handle(idConta));
        }

        [HttpPost("movimentacao")]
        public async Task<IActionResult> Post([FromBody]MoveAccountCommand model)
        {            
            return CustomResponse(await _mediatorHandler.SendCommand(model));
        }
    }
}