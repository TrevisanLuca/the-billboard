using System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Npgsql;
using TheBillboard.Abstract;
using TheBillboard.Models;
using TheBillboard.Options;

namespace TheBillboard.Readers;

public class PostgresReader : IReader
{
    private readonly string _connectionString;

    public PostgresReader(IOptions<ConnectionStringOptions> options)
    {
        _connectionString = options.Value.DefaultDatabase;
    }

    public async IAsyncEnumerable<TEntity> QueryAsync<TEntity>(string query, Func<IDataReader, TEntity> selector)
    {
        await using var connection = new NpgsqlConnection(_connectionString);

        await using var command = new NpgsqlCommand(query, connection);

        await connection.OpenAsync();
        await using var dr = command.ExecuteReader();
        while (await dr.ReadAsync())
        {
            yield return selector(dr);
        }

        await connection.CloseAsync();
        await connection.DisposeAsync();
    }

    public async Task<TEntity?> SingleQueryAsync<TEntity>(string query, Func<IDataReader, TEntity> selector)
    {
        TEntity? result = default;

        await using var connection = new NpgsqlConnection(_connectionString);
        await using var command = new NpgsqlCommand(query, connection);

        await connection.OpenAsync();
        await using var dr = command.ExecuteReader();
        if (await dr.ReadAsync())
        {
            result = selector(dr);
        }

        await connection.CloseAsync();
        await connection.DisposeAsync();
        
        return result;
    }
}