namespace TheBillboard.MVC.Models;

using System.ComponentModel.DataAnnotations;

public record Message(int? Id = default,
                   string Title = "", 
                   string Body = "", 
                   int AuthorId = default,
                   Author? Author = default,
                   string Name = "", 
                   string Surname = "", 
                   string Email = "",
                   DateTime? AuthorCreatedAt = default,
                   DateTime? MessageCreatedAt = default, 
                   DateTime? MessageUpdatedAt = default
                   )
    {

    public string FormattedCreatedAt => MessageCreatedAt.HasValue
        ? MessageCreatedAt.Value.ToString("yyyy-MM-dd HH:mm")
        : string.Empty;

    public string FormattedUpdatedAt => MessageUpdatedAt.HasValue
        ? MessageUpdatedAt.Value.ToString("yyyy-MM-dd HH:mm")
        : string.Empty;
}