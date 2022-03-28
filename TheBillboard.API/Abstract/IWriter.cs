using Dapper;
using TheBillboard.API.Domain;

namespace TheBillboard.API.Abstract
{
    public interface IWriter
    {
        Task<int?> WriteInDB<TDto>(string query, TDto objectToWrite) where TDto : DomainBase;
        Task<int> DeleteInDB(string query, object parameters);
    }
}