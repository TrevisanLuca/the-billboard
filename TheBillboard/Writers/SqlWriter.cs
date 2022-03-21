using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using TheBillboard.Abstract;
using TheBillboard.Options;

namespace TheBillboard.Writers;

public class SqlWriter : IWriter
{
    private readonly string _connectionString;

    public SqlWriter(IOptions<ConnectionStringOptions> options)
    {
        _connectionString = options.Value.DefaultDatabase;
    }

    public async Task<bool> WriteAsync(string query, IEnumerable<(string, object?)> parameters)
    {
        await using var connection = new SqlConnection(_connectionString);
        await using var command = new SqlCommand(query, connection);

        foreach (var p in parameters)
        {
            command.Parameters.Add(new SqlParameter(p.Item1, p.Item2));
        }

        await connection.OpenAsync();
        await command.ExecuteNonQueryAsync();

        await connection.CloseAsync();
        await connection.DisposeAsync();

        return true;
    }
}