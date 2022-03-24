namespace TheBillboard.API.Domain;
public record Message(
                   int? Id = default,
                   string Title = "",
                   string Body = "",
                   DateTime? MessageCreatedAt = default,
                   int AuthorId = default,
                   DateTime? MessageUpdatedAt = default,
                   string Name = "",
                   string Surname = "",
                   string Mail = "",
                   DateTime? AuthorCreatedAt = default
                   )
{

    public string FormattedCreatedAt => MessageCreatedAt.HasValue
        ? MessageCreatedAt.Value.ToString("yyyy-MM-dd HH:mm")
        : string.Empty;

    public string FormattedUpdatedAt => MessageUpdatedAt.HasValue
        ? MessageUpdatedAt.Value.ToString("yyyy-MM-dd HH:mm")
        : string.Empty;
}