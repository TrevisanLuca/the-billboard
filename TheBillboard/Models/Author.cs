using Microsoft.AspNetCore.Mvc;

namespace TheBillboard.Models
{
    public record Author
        (
        string Name = "",
        string Surname = "",
        int? Id = default,
        string? Email = "",
        DateTime? CreatedAt = null,
        DateTime? UpdatedAt = null
        )

    {

        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
}
