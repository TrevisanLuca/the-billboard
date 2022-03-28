namespace TheBillboard.API.Abstract;

using Domain;

public interface IWriter
{
    Task<int?> WriteInDBAsync<TDto>(string query, TDto objectToWrite) where TDto : DomainBase;
    Task<int> DeleteInDBAsync(string query, object parameters);
}