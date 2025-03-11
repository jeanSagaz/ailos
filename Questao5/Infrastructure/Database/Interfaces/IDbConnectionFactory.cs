using System.Data;

namespace Questao5.Infrastructure.Database.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateDbConnection(string connectionString);
    }
}
