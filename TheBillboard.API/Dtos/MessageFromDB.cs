namespace TheBillboard.API.Dtos;

public record MessageFromDB(
    int Id,
    string Title,
    string Body,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    int AuthorId,
    string Name,
    string Surname,
    string Mail
    );