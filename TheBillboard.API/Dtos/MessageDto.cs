namespace TheBillboard.API.Dtos;

using System.ComponentModel.DataAnnotations;
using TheBillboard.API.Domain;

public class MessageDto
{    public string Title { get; set; }
    public string Body { get; set; }
    public AuthorInMessageDto Author { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public MessageDto(string Title, string Body, DateTime CreatedAt, DateTime UpdatedAt, string Name, string Surname, string Mail)
    {
        this.Title = Title;
        this.Body = Body;
        this.CreatedAt = CreatedAt;
        this.UpdatedAt = UpdatedAt;
        this.Author = new AuthorInMessageDto(Name, Surname, Mail);
    }
}

//public class MessageDto
//{
//    //[Required, StringLength(10)]
//    //public string Title { get; init; } = string.Empty;

//    //[Required]
//    //public string Body { get; init; } = string.Empty;

//    //[Required]
//    //public int AuthorId { get; init; }

//    //public int? Id { get; init; }


//    public string Title { get; set; }
//    public string Body { get; set; }
//    public AuthorDto Author { get; set; }
//    public DateTime CreatedAt { get; set; }
//    public DateTime UpdatedAt { get; set; }
//    public MessageDto(string title, string body, DateTime createdAt, DateTime updatedAt, string name, string surname, string mail)
//    {
//        Title = title;
//        Body = body;
//        CreatedAt = createdAt;
//        UpdatedAt = updatedAt;
//        Author = new AuthorDto(name, surname, mail);
//    }
//}