using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using TheBillboard.Options;

namespace TheBillboard.Writers;

public class SqlWriter : IWriter
{
    private readonly string _connectionString;

    public SqlWriter(IOptions<ConnectionStringOptions> options)
    {
        _connectionString = options.Value.DefaultDatabase;
    }

    public void MapParamToCommand(DbParameterCollection parameters, string name, object? value)
    {
        parameters.Add(new SqlParameter("@" + name, value));
    }

    public async Task<bool> WriteAsync(string query, Action<DbParameterCollection> entityToQueryMapping)
    {
        await using var connection = new SqlConnection(_connectionString);
        await using var command = new SqlCommand(query, connection);
        
        entityToQueryMapping(command.Parameters);

        await connection.OpenAsync();

        await command.ExecuteNonQueryAsync();

        return true;
    }
}