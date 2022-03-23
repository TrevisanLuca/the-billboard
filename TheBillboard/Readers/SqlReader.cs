namespace TheBillboard.Readers;

using System.Data;
using System.Data.SqlClient;
using Abstract;
using Microsoft.Extensions.Options;
using Options;

public class SqlReader : IReader
{
    private readonly string _connectionString;

    public SqlReader(IOptions<ConnectionStringOptions> options)
    {
        _connectionString = options.Value.DefaultDatabase;
    }

    public async IAsyncEnumerable<TEntity> QueryAsync<TEntity>(string query, Func<IDataReader, TEntity> selector)
    {
        //var entities = new HashSet<TEntity>(); 

        await using var connection = new SqlConnection(_connectionString);
        await using var command = new SqlCommand(query, connection);

        await connection.OpenAsync();
        await using var dr = await command.ExecuteReaderAsync();
        while (await dr.ReadAsync())
        {
            var entity = selector(dr);
            yield return entity;
        }

        await connection.CloseAsync();
        await connection.DisposeAsync();

        //return entities;
    }

    public async Task<TEntity?> SingleQueryAsync<TEntity>(string query, Func<IDataReader, TEntity> selector)
    {
        TEntity? result = default;

        await using var connection = new SqlConnection(_connectionString);
        await using var command = new SqlCommand(query, connection);

        await connection.OpenAsync();
        await using var dr = await command.ExecuteReaderAsync();
        if (await dr.ReadAsync()) result = selector(dr);

        await connection.CloseAsync();
        await connection.DisposeAsync();

        return result;
    }
}