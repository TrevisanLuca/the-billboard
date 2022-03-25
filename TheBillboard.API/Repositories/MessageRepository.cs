namespace TheBillboard.API.Repositories;

using Abstract;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheBillboard.API.Dtos;

public class MessageRepository : IMessageRepository
{
    private readonly IReader _reader;

    public MessageRepository(IReader reader)
    {
        _reader = reader;
    }
    public async Task<IEnumerable<MessageDto?>> GetAllAsync()
    {
        const string query = @"SELECT M.Title, M.Body, M.CreatedAt, M.UpdatedAt,
                               A.Name, A.Surname, A.Mail FROM Message M JOIN Author A ON A.Id = M.AuthorId";
        return await _reader.QueryAsync<MessageDto>(query);
    }

    public async Task<MessageDto?> GetByIdAsync(int id)
    {
        const string query = @"SELECT M.Title, M.Body, M.CreatedAt, M.UpdatedAt,
                               A.Name, A.Surname, A.Mail FROM Message M JOIN Author A ON A.Id = M.AuthorId WHERE M.Id=@Id";


        return await _reader.GetByIdAsync<MessageDto>(query, id);      
        
    }
}