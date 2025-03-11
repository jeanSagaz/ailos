using Dapper;
using Questao5.Domain.Entities;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Database.Interfaces;

namespace Questao5.Infrastructure.Database.Repository
{
    public class IdempotencyRepository : DbConnectionRepositoryBase, IEventStore
    {
        public IdempotencyRepository(IDbConnectionFactory dbConnectionFactory,
            IConfiguration configuration) : base(dbConnectionFactory, configuration)
        {

        }

        public async Task<IEnumerable<Idempotencia>> GetIdempotencesAsync()
        {
            var sql = @"SELECT chave_idempotencia AS Id, requisicao AS Requisicao, resultado AS Resultado" +
                       "  FROM idempotencia";

            using var conn = DbConnection;
            return await conn.QueryAsync<Idempotencia>(sql);
        }

        public async Task<bool> AddIdempotencyAsync(Idempotencia idempotency)
        {
            var sql = @"INSERT INTO idempotencia (chave_idempotencia, requisicao, resultado) " +
                       "VALUES(@chave_idempotencia, @requisicao, @resultado)";

            using var conn = DbConnection;
            return await conn.ExecuteAsync(sql, new
            {
                chave_idempotencia = idempotency.Id,
                requisicao = idempotency.Requisicao,
                resultado = idempotency.Resultado,
            }) > 0;
        }
    }
}
