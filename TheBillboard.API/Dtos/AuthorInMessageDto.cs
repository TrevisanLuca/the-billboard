namespace TheBillboard.API.Dtos
{
    public class AuthorInMessageDto
    {
        public string Name { get; init; }
        public string Surname { get; init; }
        public string? Email { get; init; }

        public AuthorInMessageDto(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }
    }
}