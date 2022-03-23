namespace TheBillboard.Abstract;

public interface IWriter
{
    Task<bool> WriteAsync(string query, IEnumerable<(string, object?)> parameters);
}