namespace TheBillboard.API.Abstract;

using Dtos;

public interface IAuthorRepository
{
    IAsyncEnumerable<SimpleAuthorDto> GetAllAsync();
    Task<SimpleAuthorDto?> GetByIdAsync(int id);
    Task<int?> CreateAsync(AuthorForCreateDto author);
    Task<bool> DeleteAsync(int id);
    Task<int?> UpdateAsync(AuthorForUpdateDto author);
}