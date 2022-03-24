namespace TheBillboard.API.Repositories;

using Abstract;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

public class MessageRepository : IMessageRepository
{
    private readonly IReader _reader;

    public MessageRepository(IReader reader)
    {
        _reader = reader;
    }
    
    public async Task<IEnumerable<Message?>> GetAllAsync()
    {
        const string query = @"SELECT M.Id, M.Title, M.Body, M.CreatedAt as messageCreatedAt, M.AuthorId, M.UpdatedAt as messageUpdatedAt,
                               A.Name, A.Surname, A.Mail, A.CreatedAt as authorCreatedAt
                               FROM Message M JOIN Author A
                               ON A.Id = M.AuthorId";
        return await _reader.QueryAsync<Message>(query);
    }

    public async Task<Message?> GetByIdAsync(int id)
    {
        const string query = @"SELECT M.Id, M.Title, M.Body, M.CreatedAt as messageCreatedAt, M.AuthorId, M.UpdatedAt as messageUpdatedAt,
                               A.Name, A.Surname, A.Mail, A.CreatedAt as authorCreatedAt FROM Message M JOIN Author A ON A.Id = M.AuthorId WHERE M.Id=@Id";

        return await _reader.GetByIdAsync<Message>(query, id);        
    }
}