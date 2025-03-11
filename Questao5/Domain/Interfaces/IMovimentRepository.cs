using Questao5.Domain.Entities;

namespace Questao5.Domain.Interfaces
{
    public interface IMovimentRepository
    {
        Task<bool> AddMovimentAsync(Movimento movimento);

        Task<IEnumerable<Movimento>> GetMovimentAsync();

        Task<IEnumerable<Movimento>> GetMovimentByIdAccountAsync(string accountId);
    }
}
