using System.Data;
using System.Data.Common;

public interface IWriter
{
    Task<bool> WriteAsync(string query, Action<DbParameterCollection> mapping);
    //Task<bool> WriteAsync<TEntity>(string query, TEntity entity, Action<DbCommand, TEntity> mapping);
    void MapParamToCommand(DbParameterCollection command, string name, object? value);
}