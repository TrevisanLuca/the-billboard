namespace TheBillboard.MVC.ViewModels;

using Models;

public record MessagesIndexViewModel(MessageCreationViewModel MessageCreationViewModel, IAsyncEnumerable<Message> Messages);