using System.Data;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Database.Interfaces;

namespace Questao5.Infrastructure.Database
{
    public class DapperDbConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection CreateDbConnection(string connectionString)
        {
            return new SqliteConnection(connectionString);
        }
    }
}
