namespace TheBillboard.API.Dtos;

using System.ComponentModel.DataAnnotations;

public record MessageForCreateDto(
    [Required] [MinLength(2)]
    string Title,
    [Required] [MinLength(2)]
    string Body,
    [Required][Range(1,int.MaxValue)]
    int AuthorId
    );