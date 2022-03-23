namespace TheBillboard.MVC.Abstract;

public interface IWriter
{
    Task<bool> WriteAsync(string query, IEnumerable<(string, object?)> parameters);
}