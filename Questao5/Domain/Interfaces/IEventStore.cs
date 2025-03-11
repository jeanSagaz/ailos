using Questao5.Core.Messages;
using Questao5.Domain.Entities;

namespace Questao5.Domain.Interfaces
{
    public interface IEventStore
    {
        Task<IEnumerable<Idempotencia>> GetIdempotencesAsync();

        Task<bool> AddIdempotencyAsync(Idempotencia idempotency);
    }
}
