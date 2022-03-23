namespace TheBillboard.API.Repositories;

using Abstract;
using Domain;

public class MessageRepository : IMessageRepository
{
    private readonly Message[] _messages = {
        new()
        {
            Author = new Author()
            {
                Id = 1,
                Name = "John",
                Surname = "Doe",
                Email = "john.dow.mail.com",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            Id = 1,
            Title = "Hello",
            Body = "Hello World!",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            AuthorId = 1
        },
        new()
        {
            Author = new Author()
            {
                Id = 2,
                Name = "Jane",
                Surname = "Doe",
                Email = "jane.doe.mail.com",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            Id = 2,
            Title = "Hi",
            Body = "Hi World!",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            AuthorId = 2
        }
    };
    
    public IEnumerable<Message> GetAll()
    {
        return _messages;
    }

    public Message GetById(int id)
    {
        return _messages.FirstOrDefault(m => m.Id == id);
    }
}