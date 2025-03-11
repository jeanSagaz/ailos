using MediatR;
using Questao5.Application;
using Questao5.Domain.Entities;
using Questao5.Domain.Interfaces;

namespace Questao5.Core.Mediator
{
    public sealed class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public MediatorHandler(IEventStore eventStore, IMediator mediator)
        {
            _eventStore = eventStore;
            _mediator = mediator;
        }

        public async Task PublishEvent(Idempotencia @event)
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStore?.AddIdempotencyAsync(@event);

            await _mediator.Publish(@event);
        }

        public async Task<object?> SendCommand<T>(T command) where T : BaseRequest
            => await _mediator.Send(command);        
    }
}
