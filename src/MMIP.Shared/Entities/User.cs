using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MMIP.Shared.Entities
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Een voornaam is vereist")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Een achternaam is vereist")]
        public string LastName { get; set; } = null!;

        public string? Preposition { get; set; }

        [Required(ErrorMessage = "Een omschrijving is vereist")]
        public string Description { get; set; } = null!;

        public string PasswordHash { get; set; }

        public string? FullName { get; set; }
        public string? AvatarPath { get; set; }
    }
}
