namespace TheBillboard.MVC.ViewModels;

using Models;

public record MessageCreationViewModel(Message Message, IAsyncEnumerable<Author> Authors);