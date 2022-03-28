namespace TheBillboard.API.Abstract;

using Domain;
using TheBillboard.API.Dtos;

public interface IMessageRepository
{
    IAsyncEnumerable<SimpleMessageDto> GetAllAsync();
    Task<SimpleMessageDto?> GetByIdAsync(int id);
    Task<int?> CreateAsync(MessageForCreateDto message);
    Task<int> DeleteAsync(int id);
    Task<int?> UpdateAsync(MessageForUpdateDto message);
}