using Dapper;
using Questao5.Domain.Entities;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Database.Interfaces;

namespace Questao5.Infrastructure.Database.Repository
{

    public class ContaCorrenteRepository : DbConnectionRepositoryBase, IContaCorrenteRepository
    {
        public ContaCorrenteRepository(IDbConnectionFactory dbConnectionFactory,
            IConfiguration configuration) : base(dbConnectionFactory, configuration)
        {

        }

        public async Task<ContaCorrente?> GetContaCorrenteByIdAsync(string id)
        {
            var sql = @"SELECT idcontacorrente as Id, numero as Numero, nome as Nome, ativo as Ativo" +
                       " FROM contacorrente WHERE idcontacorrente = @Id";

            using var conn = DbConnection;
            return await conn.QueryFirstOrDefaultAsync<ContaCorrente>(sql, new { Id = id });
        }
    }
}
