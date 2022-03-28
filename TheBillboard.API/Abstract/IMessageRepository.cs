namespace TheBillboard.API.Abstract;

using Dtos;

public interface IMessageRepository
{
    IAsyncEnumerable<SimpleMessageDto> GetAllAsync();
    Task<SimpleMessageDto?> GetByIdAsync(int id);
    Task<int?> CreateAsync(MessageForCreateDto message);
    Task<bool> DeleteAsync(int id);
    Task<int?> UpdateAsync(MessageForUpdateDto message);
}