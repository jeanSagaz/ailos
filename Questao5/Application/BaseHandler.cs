using FluentValidation.Results;
using Questao5.Core.Notifications.Interfaces;
using Questao5.Core.Notifications.Model;

namespace Questao5.Application
{
    public abstract class BaseHandler
    {
        protected IDomainNotifier _domainNotifier;

        protected BaseHandler(IDomainNotifier domainNotifier)
        {
            _domainNotifier = domainNotifier;
        }

        protected void Notifier(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors) 
            {
                Notifier(error.ErrorMessage, error.PropertyName);
            }
        }

        protected void Notifier(string message, string? key = null)
        {
            _domainNotifier.Add(new DomainNotification(message, key));
        }
    }
}
