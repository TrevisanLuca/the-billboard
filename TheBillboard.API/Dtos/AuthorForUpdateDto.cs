using System.ComponentModel.DataAnnotations;

namespace TheBillboard.API.Dtos
{
    public record AuthorForUpdateDto(
        [Required][Range(1,int.MaxValue)]
        int id,
        [Required][MinLength(2)]
        string Name,
        [Required][MinLength(2)]
        string Surname,
        [Required][EmailAddress]
        string Email
        );
}
