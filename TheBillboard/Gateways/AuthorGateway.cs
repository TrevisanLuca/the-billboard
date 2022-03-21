using System.Data;
using TheBillboard.Abstract;
using TheBillboard.Models;

namespace TheBillboard.Gateways;

public class AuthorGateway : IAuthorGateway
{
    private readonly IReader _reader;
    private readonly IWriter _writer;

    public AuthorGateway(IReader reader, IWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    private Author MapAuthor(IDataReader dr)
    {
        return new Author
        {
            Id = dr["Id"] as int?,
            Name = dr["Name"].ToString()!,
            Surname = dr["Surname"].ToString()!,
            Email = dr["Mail"].ToString(),
            CreatedAt = dr["createdAt"] as DateTime?            
        };
    }

    public Task<bool> Create(Author author)
    {
        var query = @"INSERT INTO ""Author""(""Name"", ""Surname"", ""Mail"", ""CreatedAt"")
                        VALUES (@Name, @Surname, @Email, @CreatedAt)";

        var parameters = new List<(string, object?)>
        {
            ("@Name", author.Name),
            ("@Surname", author.Surname),
            ("@Email", author.Email),
            ("@CreatedAt", DateTime.Now),
        };

        return _writer.WriteAsync(query, parameters);
    }

    public Task<bool> Delete(int id)
    {
        var query = @"DELETE FROM ""Author"" WHERE (Id=@Id)";
        return _writer.WriteAsync(query, new[] { ("@Id", (object?)id) });
    }

    public Task<IEnumerable<Author>> GetAll()
    {
        const string query = @"select * from ""Author""";

        return _reader.QueryAsync(query, MapAuthor);
    }

    public Task<Author?> GetById(int id)
    {
        var query = $@"select * 
                    from ""Author""
                    where ""Id""={id}";
        return _reader.SingleQueryAsync(query, MapAuthor);
    }
}
