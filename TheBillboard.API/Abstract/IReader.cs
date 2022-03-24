using System.Data;

namespace TheBillboard.API.Abstract
{
    public interface IReader
    {
        Task<IEnumerable<TEntity?>> QueryAsync<TEntity>(string query);
        public Task<TEntity?> GetByIdAsync<TEntity>(string query, int id);
    }
}
