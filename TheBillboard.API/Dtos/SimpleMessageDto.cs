namespace TheBillboard.API.Dtos;

public record SimpleMessageDto(
    int id,
    string Title,
    string Body,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    SimpleAuthorDto author
    );