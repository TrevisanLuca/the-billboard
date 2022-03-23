namespace TheBillboard.MVC.Abstract;

using Models;

public interface IAuthorGateway
{
    public IAsyncEnumerable<Author> GetAll();

    Task<Author?> GetById(int id);

    Task<bool> Create(Author author);

    Task<bool> Delete(int id);
}