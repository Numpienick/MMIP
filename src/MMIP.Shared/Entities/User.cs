using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MMIP.Shared.Entities
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Een omschrijving is vereist")]
        public string Description { get; set; }

        public string? AvatarPath { get; set; }

        [Required(ErrorMessage = "Een voornaam is vereist")]
        public string FirstName { get; set; }

        public string? Preposition { get; set; }

        [Required(ErrorMessage = "Een achternaam is vereist")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Een e-mailadres is vereist")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Een wachtwoord is vereist")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(
            "Password",
            ErrorMessage = "Het controle wachtwoord komt niet overeen met het wachtwoord"
        )]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }
    }
}
