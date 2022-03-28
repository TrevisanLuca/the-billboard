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

        public async IAsyncEnumerable<SimpleAuthorDto> GetAllAsync()
        {
            const string query = @"SELECT * FROM Author";
            var queryResult = await _reader.QueryTEntityAsync<Author>(query);
            foreach (var author in queryResult)
                yield return new SimpleAuthorDto(author.Id, author.Name, author.Surname, author.Mail);
        }
        public async Task<SimpleAuthorDto?> GetByIdAsync(int id)
        {
            const string query = @"SELECT * FROM Author WHERE Id=@Id";
            var queryResult = await _reader.QuerySingleTEntityAsync<Author>(query, new { Id = id });
            return queryResult is null
                ? null
                : new SimpleAuthorDto(queryResult.Id, queryResult.Name, queryResult.Surname, queryResult.Mail);
        }
        public async Task<int?> CreateAsync(AuthorForCreateDto author)
        {
            const string query = @"INSERT INTO [dbo].[Author]
                                         ([Name]
                                         ,[Surname]
                                         ,[Mail]
                                         ,[CreatedAt]
                                         ,[UpdatedAt]) 
                                   OUTPUT inserted.[Id]
                                   VALUES
                                         (@Name, 
                                          @Surname,
                                          @Mail, 
                                          @CreatedAt, 
                                          @UpdatedAt)";
            var authorForQuery = new Author(default, author.Name, author.Surname, author.Email, DateTime.Now, DateTime.Now);
            return await _writer.WriteInDBAsync(query, authorForQuery);
        }
        public async Task<int?> UpdateAsync(AuthorForUpdateDto author)
        {
            const string query = @"UPDATE Author
                                   SET Name = @Name, Surname = @Surname, Mail = @Mail, UpdatedAt = @UpdatedAt 
                                   OUTPUT inserted.[Id] 
                                   WHERE Id = @Id";
            var authorForQuery = new Author(author.id, author.Name, author.Surname, author.Email, default, DateTime.Now);
            return await _writer.WriteInDBAsync(query, authorForQuery);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            const string query = @"DELETE FROM Author
                                   WHERE Id = @Id";
            return await _writer.DeleteInDBAsync(query, new { Id = id }) > 0;
        }
    }
}