using Dapper;
using TheBillboard.API.Abstract;
using TheBillboard.API.Domain;
using TheBillboard.API.Dtos;

namespace TheBillboard.API.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

        public AuthorRepository(IReader reader, IWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public async Task<IEnumerable<Author?>> GetAllAsync()
        {
            const string query = @"SELECT Id, Name, Surname, Mail, CreatedAt
                               FROM Author";

            return await _reader.QueryAsync<Author>(query);
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            var query = $@"SELECT Id, Name, Surname, Mail, CreatedAt
                       FROM Author
                       WHERE Id=@Id";

            return await _reader.GetByIdAsync<Author>(query,id);
        }

        public async Task<bool> Create(AuthorDto author)
        {
            const string query = "";
            var parameters = new DynamicParameters();
        //parameters.Add("Title", author.Title, DbType.String);
            
           //new AuthorDto()
           // {
           //     Name = author.Name,
           //     Surname = author.Surname,
           //     Email = author.Email
           // };
            await _writer.WriteAsync(query, parameters);
            //return new Author();
            return true;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Author author)
        {
            throw new NotImplementedException();
        }
    }
}

// insert into message(...) output inserted.id values(...)

/*
 * public MessageDto Create(MessageDto message)
    {
        var lastId = _messages.Max(m => m.Id);
        var newId = (lastId ?? 0) + 1;
        
        var newMessage = new Message(newId, message.Title, message.Body, message.AuthorId, DateTime.Now, default);
        _messages.Add(newMessage);
        
        return new MessageDto()
        {
            Title = newMessage.Title,
            Body = newMessage.Body,
            AuthorId = newMessage.AuthorId,
            Id = newId
        };
    }
 */
