using TheBillboard.Models;

namespace TheBillboard.ViewModels
{
    public record MessagesIndexViewModel(MessageCreationViewModel MessageCreationViewModel, IAsyncEnumerable<Message> Messages);
}
