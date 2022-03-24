using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using TheBillboard.API.Abstract;
using TheBillboard.API.Options;
using Dapper;

namespace TheBillboard.API.Readers
{
    public class SQLReader : IReader
    {
        private readonly string _connectionString;

        public SQLReader(IOptions<ConnectionStringOptions> options)
        {
            _connectionString = options.Value.DefaultDatabase;
        }

        public async Task<IEnumerable<TEntity?>> QueryAsync<TEntity>(string query)
        {
            await using var conn = new SqlConnection { ConnectionString = _connectionString };
            IEnumerable<TEntity?> result = await conn.QueryAsync<TEntity>(query, commandType: CommandType.Text, commandTimeout: 10);
            return result;            
        }

        public async Task<TEntity?> GetByIdAsync<TEntity>(string query, int id)
        {
            await using var conn = new SqlConnection { ConnectionString = _connectionString };
            IEnumerable<TEntity?> result = await conn.QueryAsync<TEntity>(query, param: new { Id = id }, commandType: CommandType.Text, commandTimeout: 10);

            return result.FirstOrDefault();
        }
    }
}
