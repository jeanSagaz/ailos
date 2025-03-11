using Dapper;
using Questao5.Domain.Entities;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Database.Interfaces;

namespace Questao5.Infrastructure.Database.Repository
{
    public class MovimentRepository : DbConnectionRepositoryBase, IMovimentRepository
    {
        public MovimentRepository(IDbConnectionFactory dbConnectionFactory,
            IConfiguration configuration) : base(dbConnectionFactory, configuration)
        {

        }

        public async Task<bool> AddMovimentAsync(Movimento movimento)
        {
            var sql = @"INSERT INTO movimento(idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) " +
                       "VALUES(@idmovimento, @idcontacorrente, @datamovimento, @tipomovimento, @valor)";

            using var conn = DbConnection;
            return await conn.ExecuteAsync(sql, new
            {
                idmovimento = movimento.Id,
                idcontacorrente = movimento.IdContaCorrente,
                datamovimento = movimento.DataMovimento,
                tipomovimento = movimento.TipoMovimento,
                valor = movimento.Valor,
            }) > 0;
        }

        public async Task<IEnumerable<Movimento>> GetMovimentAsync()
        {
            var sql = @"SELECT idmovimento AS Id, idcontacorrente AS IdContaCorrente, datamovimento AS DataMovimento, tipomovimento AS TipoMovimento, valor AS Valor" +
                       "  FROM movimento";

            using var conn = DbConnection;
            return await conn.QueryAsync<Movimento>(sql);
        }

        public async Task<IEnumerable<Movimento>> GetMovimentByIdAccountAsync(string accountId)
        {
            var sql = @"SELECT idmovimento AS Id, idcontacorrente AS IdContaCorrente, datamovimento AS DataMovimento, tipomovimento AS TipoMovimento, valor AS Valor" +
                       "  FROM movimento WHERE idcontacorrente = @idcontacorrente";

            using var conn = DbConnection;
            return await conn.QueryAsync<Movimento>(sql, new { idcontacorrente = accountId });
        }
    }
}
