namespace TheBillboard.API.Domain;

public record Message(
    int Id = 0,
    string Title = "",
    string Body = "",
    DateTime? CreatedAt = default,
    DateTime? UpdatedAt = default,
    int AuthorId = 0) : DomainBase(Id, CreatedAt, UpdatedAt);