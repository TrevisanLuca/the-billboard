namespace TheBillboard.Abstract;

using System.Data;

public interface IReader
{
    public IAsyncEnumerable<TEntity> QueryAsync<TEntity>(string query, Func<IDataReader, TEntity> selector);
    public Task<TEntity?> SingleQueryAsync<TEntity>(string query, Func<IDataReader, TEntity> selector);
    public Task<TEntity?> GetByIdAsync<TEntity>(string query, int id);
}