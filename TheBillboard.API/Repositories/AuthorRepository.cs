using TheBillboard.API.Abstract;
using TheBillboard.API.Domain;

namespace TheBillboard.API.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IReader _reader;

        public AuthorRepository(IReader reader)
        {
            _reader = reader;
        }

        public async Task<IEnumerable<Author?>> GetAllAsync()
        {
            const string query = @"SELECT Id, Name, Surname, Mail, CreatedAt
                               FROM Author";

            return await _reader.QueryAsync<Author>(query);
        }

        public async Task<Author?> GetById(int id)
        {
            var query = $@"SELECT Id, Name, Surname, Mail, CreatedAt
                       FROM Author
                       WHERE Id=@Id";

            return await _reader.GetByIdAsync<Author>(query,id);
        }
    }
}
