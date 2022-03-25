using TheBillboard.API.Domain;
using TheBillboard.API.Dtos;

namespace TheBillboard.API.Abstract
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<AuthorDto?>> GetAllAsync();
        Task<AuthorDto?> GetByIdAsync(int id);
        Task<bool> Delete(int id);
        Task<int> Create(AuthorInMessageDto author);
    }
}
