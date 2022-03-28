namespace TheBillboard.API.Dtos
{
    public record MessageFromDB(
        int Id,
        string Title,
        string Body,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        string Name,
        string Surname,
        string Mail
        );
}
