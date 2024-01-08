using System.ComponentModel.DataAnnotations;

namespace MMIP.Shared.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Een e-mailadres is vereist")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Een wachtwoord is vereist")]
        [StringLength(
            254,
            ErrorMessage = "Het wachtwoord moet minstens 6 karakters lang zijn en maximaal 254",
            MinimumLength = 6
        )]
        [DataType(DataType.Password)]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$",
            ErrorMessage = "Het wachtwoord moet minstens 1 hoofdletter, 1 kleine letter, 1 cijfer en 1 bijzonder karakter bevatten."
        )]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "De wachtwoorden komen niet overeen met elkaar")]
        public string RepeatPassword { get; set; }

        [Required(ErrorMessage = "Een voornaam is vereist")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Een achternaam is vereist")]
        public string LastName { get; set; } = null!;
        public string? Preposition { get; set; }

        [Required(ErrorMessage = "Een omschrijving is vereist")]
        public string Description { get; set; } = null!;
        public string? AvatarPath { get; set; }

        [Range(
            typeof(bool),
            "true",
            "true",
            ErrorMessage = "Acceptatie van de voorwaarden is verplicht"
        )]
        public bool AgreedToPrivacy { get; set; }
        public DateTime? AgreedToPrivacyDateTimeStamp { get; set; }
    }
}
