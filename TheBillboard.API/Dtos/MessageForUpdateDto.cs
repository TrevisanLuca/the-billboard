namespace TheBillboard.API.Dtos;

using System.ComponentModel.DataAnnotations;

public record MessageForUpdateDto(
    [Required][Range(1,int.MaxValue)]
    int Id,
    [Required][MinLength(2)]
    string Title,
    [Required][MinLength(2)]
    string Body);