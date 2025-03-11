namespace Questao5.Application.Queries
{
    public interface IAccountBalanceQueriesHandler
    {
        Task<object?> Handle(string accountId);
    }
}
