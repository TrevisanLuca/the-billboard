using Dapper;
using TheBillboard.API.Domain;

namespace TheBillboard.API.Abstract
{
    public interface IWriter
    {
        Task<int?> WriteInDBAsync<TDto>(string query, TDto objectToWrite) where TDto : DomainBase;
        Task<int> DeleteInDBAsync(string query, object parameters);
    }
}