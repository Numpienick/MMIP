using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MMIP.Shared.Entities
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Een e-mailadres is vereist")]
        [EmailAddress]
        public override string? Email { get; set; }

        public override string? UserName => Email;

        [Required(ErrorMessage = "Een voornaam is vereist")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Een achternaam is vereist")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Een omschrijving is vereist")]
        public string Description { get; set; } = null!;

        public string? AvatarPath { get; set; }
        public string? Preposition { get; set; }
    }
}
