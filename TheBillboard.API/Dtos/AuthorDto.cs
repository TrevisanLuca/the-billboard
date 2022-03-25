namespace TheBillboard.API.Dtos
{
    public class AuthorDto
    {        
        public string Name { get; init; }
        public string Surname { get; init; }
        public string? Email { get; init; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public AuthorDto(string name, string surname, string mail,DateTime createdAt,DateTime updatedAt)
        {
        Name = name;
        Surname = surname;
        Email = mail;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        }
}
}
