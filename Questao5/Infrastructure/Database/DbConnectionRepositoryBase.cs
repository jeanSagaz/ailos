using System.Data;
using Questao5.Infrastructure.Database.Interfaces;

namespace Questao5.Infrastructure.Database
{
    public abstract class DbConnectionRepositoryBase
    {
        public IDbConnection DbConnection { get; private set; }

        public DbConnectionRepositoryBase(IDbConnectionFactory dbConnectionFactory, IConfiguration configuration)
        {
            DbConnection = dbConnectionFactory.CreateDbConnection(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
