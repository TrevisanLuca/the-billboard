using System.ComponentModel.DataAnnotations;

namespace TheBillboard.API.Options
{
    public class ConnectionStringOptions
    {
        [Required] public string DefaultDatabase { get; set; } = null!;
    }
}
