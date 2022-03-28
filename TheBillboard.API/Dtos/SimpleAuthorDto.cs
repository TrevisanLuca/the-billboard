namespace TheBillboard.API.Dtos;

public record SimpleAuthorDto(
    int? Id,
    string Name,
    string Surname,
    string Email
    );