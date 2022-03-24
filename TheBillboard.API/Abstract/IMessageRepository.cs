namespace TheBillboard.API.Abstract;

using Domain;

public interface IMessageRepository
{
    Task<IEnumerable<Message?>> GetAllAsync();
    Task<Message?> GetByIdAsync(int id);
}