namespace TheBillboard.Options;

using System.ComponentModel.DataAnnotations;

public class AppOptions
{
    [Required] [MinLength(5)] public IEnumerable<string> Students { get; set; } = null!;
}