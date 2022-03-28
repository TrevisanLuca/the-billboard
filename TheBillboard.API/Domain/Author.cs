namespace TheBillboard.API.Domain;

public record Author(
        int Id = 0,
        string Name = "",
        string Surname = "",
        string Mail = "",
        DateTime? CreatedAt = default,
        DateTime? UpdatedAt = default
        ) : DomainBase(Id, CreatedAt, UpdatedAt);