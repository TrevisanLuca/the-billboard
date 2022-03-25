using Dapper;
using System.Data;
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

        public async Task<IEnumerable<AuthorDto?>> GetAllAsync()
        {
            const string query = @"SELECT Name, Surname, Mail, CreatedAt, UpdatedAt
                               FROM Author";

            return await _reader.QueryAsync<AuthorDto>(query);
        }

        public async Task<AuthorDto?> GetByIdAsync(int id)
        {
            const string query = $@"SELECT Name, Surname, Mail, CreatedAt, UpdatedAt
                       FROM Author
                       WHERE Id=@Id";

            return await _reader.GetByIdAsync<AuthorDto>(query, id);
        }

        public async Task<int> Create(AuthorInMessageDto author)
        {
            
            const string query = $@"INSERT INTO [dbo].[Author]
           ([Name]
           ,[Surname]
           ,[Mail]
           ,[CreatedAt]
           ,[UpdatedAt]) 
            OUTPUT inserted.[Id]
            VALUES
           (@Name
           ,@Surname
           ,@Mail
           ,@CreatedAt
           ,@UpdatedAt)";

            var parameters = new DynamicParameters();
            parameters.Add("@Name", author.Name, DbType.String);
            parameters.Add("@Surname", author.Surname, DbType.String);
            parameters.Add("@Mail", author.Email, DbType.String);
            parameters.Add("@CreatedAt", DateTime.Now, DbType.DateTime);
            parameters.Add("@UpdatedAt", DateTime.Now, DbType.DateTime);  

            var result = await _writer.WriteWithReturnAsync<int>(query, parameters);
            return result;
        }

        public Task<bool> Delete(int id)
        {
            const string query = $@"DELETE FROM [dbo].[Author] WHERE Id=@Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            return _writer.WriteAsync(query, parameters);
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
