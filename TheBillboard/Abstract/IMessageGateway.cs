namespace TheBillboard.MVC.Abstract;

using Models;

public interface IMessageGateway
{
    IAsyncEnumerable<Message> GetAll();
    Task<Message?> GetById(int id);
    Task<bool> Create(Message message);
    Task<bool> Update(Message message);
    Task<bool> Delete(int id);
}