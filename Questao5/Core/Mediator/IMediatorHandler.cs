using Questao5.Application;
using Questao5.Domain.Entities;

namespace Questao5.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent(Idempotencia @event);

        Task<object?> SendCommand<T>(T command) where T : BaseRequest;
    }
}
