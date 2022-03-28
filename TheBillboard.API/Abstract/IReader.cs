using System.Data;
using TheBillboard.API.Domain;

namespace TheBillboard.API.Abstract
{
    public interface IReader
    {
        Task<IEnumerable<TEntity>> QueryTEntityAsync<TEntity>(string query);
        Task<TEntity> QuerySingleTEntityAsync<TEntity>(string query, object parameters);
    }
}