namespace TheBillboard.API.Dtos;

using System.ComponentModel.DataAnnotations;

public record AuthorForCreateDto(
     [Required][MinLength(2)]
    string Name,
     [Required][MinLength(2)]
    string Surname,
     [Required][EmailAddress]
    string Email
     );