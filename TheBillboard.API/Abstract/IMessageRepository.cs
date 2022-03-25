namespace TheBillboard.API.Abstract;

using Domain;
using TheBillboard.API.Dtos;

public interface IMessageRepository
{
    Task<IEnumerable<MessageDto?>> GetAllAsync();
    Task<MessageDto?> GetByIdAsync(int id);
}