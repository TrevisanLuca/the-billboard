namespace TheBillboard.API.Abstract;

using Domain;

public interface IMessageRepository
{
    IEnumerable<Message> GetAll();
    Message? GetById(int id);
}