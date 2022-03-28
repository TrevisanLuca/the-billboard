using Dapper;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using TheBillboard.API.Abstract;
using TheBillboard.API.Domain;
using TheBillboard.API.Options;

namespace TheBillboard.API.Writer
{
    public class SQLWriter : IWriter
    {
        private readonly string _connectionstring;
        public SQLWriter(IOptions<ConnectionStringOptions> options) => _connectionstring = options.Value.DefaultDatabase;

        public async Task<int?> WriteInDB<TDto>(string query, TDto objectToWrite) where TDto : DomainBase =>
            (await new SqlConnection(_connectionstring).ExecuteScalarAsync(query, objectToWrite, commandTimeout: 10)) as int?;

        public async Task<int> DeleteInDB(string query, object parameters)
        {
            try
            {
                return await new SqlConnection(_connectionstring).ExecuteAsync(query, parameters);
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}