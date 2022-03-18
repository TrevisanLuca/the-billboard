using System.Data;
using System.Data.Common;
using TheBillboard.Abstract;
using TheBillboard.Models;

namespace TheBillboard.Gateways;

public class MessageGateway : IMessageGateway
{
    private readonly IReader _reader;
    private readonly IWriter _writer;

    public MessageGateway(IReader reader, IWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    private Message MapMessage(IDataReader dr)
    {
        return new Message
        {
            Id = dr["id"] as int?,
            Body = dr["body"].ToString()!,
            Title = dr["title"].ToString()!,
            CreatedAt = dr["createdAt"] as DateTime?,
            UpdatedAt = dr["updatedAt"] as DateTime?,
            AuthorId = (int)dr["authorId"],
            Author = new Author
            {
                Id = dr["authorId"] as int?,
                Name = dr["name"].ToString()!,
                Surname = dr["surname"].ToString()!,
            }
        };
    }

    public Task<IEnumerable<Message>> GetAll()
    {
        const string query = @"select * from ""Message"" join ""Author"" A on A.""Id"" = ""Message"".""AuthorId""";

        return _reader.QueryAsync(query, MapMessage);
    }

    public async Task<Message?> GetById(int id)
    {
        var query = $@"select * 
                    from ""Message"" join ""Author"" A on A.""Id"" = ""Message"".""AuthorId""
                    where ""Message"".""AuthorId""={id}";
        var result = await _reader.QueryAsync(query, MapMessage);

        return result.FirstOrDefault();
    }

    public void QueryMapping(DbParameterCollection parameters, Message message)
    {
        _writer.MapParamToCommand(parameters, "Title", message.Title);
        _writer.MapParamToCommand(parameters, "Body", message.Body);
        _writer.MapParamToCommand(parameters, "CreatedAt", message.CreatedAt);
        _writer.MapParamToCommand(parameters, "UpdatedAt", message.UpdatedAt);
        _writer.MapParamToCommand(parameters, "AuthorId", message.AuthorId);
    }

    public Task<bool> Create(Message message)
    {
        var query = @"INSERT INTO ""Message""(""Title"", ""Body"", ""CreatedAt"", ""UpdatedAt"", ""AuthorId"")
                        VALUES (@Title, @Body, @CreatedAt, @UpdatedAt, @AuthorId)";

        return _writer.WriteAsync(query, parameters => QueryMapping(parameters, message));
    }

    //TODO substitute Delete and Update methods
    public async Task<bool> Delete(int id)
    {
        var query = @"DELETE FROM public.""Message"" WHERE (Id='@Id')";
        return await _writer.WriteAsync(query, parameters => {
            _writer.MapParamToCommand(parameters, "Id", id);
        });
    }


    public async Task<bool> Update(Message message)
    {
        // TODO remove unnecessary variables in SET
        var query = @"UPDATE public.""Message""(""Title"", ""Body"", ""CreatedAt"", ""UpdatedAt"", ""AuthorId"")
                      SET (Title='@Title',Body='@Body',CreatedAt='@CreatedAt',UpdatedAt='@UpdatedAt',AuthorId='@AuthorId')
                      WHERE (Id='@Id')";
        // TODO: Passare Id alla query
        return await _writer.WriteAsync(query, command => QueryMapping(command, message));
    }

    //public async Task<bool> Delete(int id)
    //{
    //    var query = $@"delete * 
    //                from ""Message"" join ""Author"" A on A.""Id"" = ""Message"".""AuthorId""
    //                where ""Message"".""AuthorId""={id}";
    //    return await _writer.WriteAsync(query, _ => { });
    //}

    /*
    public void Update(Message message)
    {
        //_messages = _messages
        //    .Where(m => m.Id != message.Id)
        //    .ToList();

        //message = message with { UpdatedAt = DateTime.Now };

        //_messages.Add(message);
        throw new NotImplementedException();
    }
    */
}