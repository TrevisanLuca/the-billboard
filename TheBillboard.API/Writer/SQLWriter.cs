using Dapper;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using TheBillboard.API.Abstract;
using TheBillboard.API.Options;

namespace TheBillboard.API.Writer
{
    public class SQLWriter : IWriter
    {
        private readonly string _connectionString;

        public SQLWriter(IOptions<ConnectionStringOptions> options)
        {
            _connectionString = options.Value.DefaultDatabase;
        }

        public async Task<bool> WriteAsync(string query, DynamicParameters parameters)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(query, parameters);
            return true;
        }
        public async Task<TEntity> WriteWithReturnAsync<TEntity>(string query, DynamicParameters parameters)
        {
            await using var connection = new SqlConnection(_connectionString);
            var result = await connection.QuerySingleAsync<TEntity>(query, parameters);
            return result;
        }
    }
}