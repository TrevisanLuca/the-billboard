namespace TheBillboard.API.Repositories;

using Abstract;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheBillboard.API.Dtos;

public class MessageRepository : IMessageRepository
{
    private readonly IReader _reader;
    private readonly IWriter _writer;

    public MessageRepository(IReader reader, IWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public async IAsyncEnumerable<SimpleMessageDto> GetAllAsync()
    {
        const string query = @"SELECT M.Id, M.Title, M.Body, M.CreatedAt, M.UpdatedAt, M.AuthorId,
                               A.Name, A.Surname, A.Mail FROM Message M JOIN Author A ON A.Id = M.AuthorId";
        var queryResult = await _reader.QueryTEntityAsync<MessageFromDB>(query);
        foreach (var message in queryResult)
            yield return new SimpleMessageDto(message.Id, message.Title, message.Body, message.CreatedAt, message.UpdatedAt, new SimpleAuthorDto(message.AuthorId, message.Name,message.Surname,message.Mail));
    }

    public async Task<SimpleMessageDto?> GetByIdAsync(int id)
    {
        const string query = @"SELECT M.Id, M.Title, M.Body, M.CreatedAt, M.UpdatedAt, M.AuthorId,
                               A.Name, A.Surname, A.Mail FROM Message M JOIN Author A ON A.Id = M.AuthorId WHERE M.Id=@Id";
        var queryResult = await _reader.QuerySingleTEntityAsync<MessageFromDB>(query, new { Id = id });

        return queryResult is null ? 
            null : 
            new SimpleMessageDto(queryResult.Id, queryResult.Title, queryResult.Body, queryResult.CreatedAt, queryResult.UpdatedAt, new SimpleAuthorDto(queryResult.AuthorId, queryResult.Name, queryResult.Surname, queryResult.Mail));
    }

    public async Task<int?> CreateAsync(MessageForCreateDto message)
    {
        const string query = @"INSERT INTO [dbo].[Message]
                                           ([Title]
                                           ,[Body]
                                           ,[CreatedAt]
                                           ,[UpdatedAt]
                                           ,[AuthorId])
                                     OUTPUT inserted.[Id]
                                     VALUES
                                           (@Title
                                           ,@Body
                                           ,@CreatedAt
                                           ,@UpdatedAt
                                           ,@AuthorId)";

        var messageForQuery = new Message(default, message.Title, message.Body, DateTime.Now, DateTime.Now, message.AuthorId);

        return await _writer.WriteInDBAsync(query, messageForQuery);
    }

    public async Task<int?> UpdateAsync(MessageForUpdateDto message)
    {
        const string query = @"UPDATE [dbo].[Message]
                                  SET [Title] = @Title
                                     ,[Body] = @Body
                                     ,[UpdatedAt] = @UpdatedAt
                               OUTPUT inserted.[Id]
                                WHERE Id=@Id";

        var messageForQuery = new Message(message.Id, message.Title, message.Body, default, DateTime.Now, default);

        return await _writer.WriteInDBAsync(query, messageForQuery);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        const string query = @"DELETE FROM Message
                                   WHERE Id = @Id";
        return await _writer.DeleteInDBAsync(query, new { Id = id }) > 0;
    }
}