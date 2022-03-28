using System.ComponentModel.DataAnnotations;

namespace TheBillboard.API.Dtos
{
    public record MessageForUpdateDto(
        [Required][Range(1,int.MaxValue)]
        int Id,
        [Required][MinLength(2)]
        string Title,
        [Required][MinLength(2)]
        string Body);
}
