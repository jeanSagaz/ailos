using Microsoft.AspNetCore.Mvc;
using Questao5.Core.Notifications.Interfaces;
using Questao5.Core.Notifications.Model;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private readonly IDomainNotifier _notifier;

        public BaseController(IDomainNotifier notifier)
        {
            _notifier = notifier;
        }

        protected ActionResult CustomResponse(object? result = null)
        {
            if (HasNotification())
            {
                return Ok(result);
            }

            //return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            //{
            //    { "messages", _notifier.GetNotifications().Select(n => n.Value).ToArray() }
            //}));

            return BadRequest(new
            {
                errors = _notifier.GetNotifications().Select(n => new { n.Key, n.Value })
            });
        }

        protected bool HasNotification()
        {
            return !_notifier.HasNotification();
        }

        protected void NotifyError(string key, string message)
        {
            _notifier.Add(new DomainNotification(key, message));
        }
    }
}
