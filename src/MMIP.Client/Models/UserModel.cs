using System.ComponentModel.DataAnnotations;
using MMIP.Shared.Entities;

namespace MMIP.Client.Models
{
    public class UserModel : User
    {
        [Required(ErrorMessage = "Een e-mailadres is vereist")]
        [EmailAddress]
        public string Email { get; set; }

        public override string? UserName => Email;

        [Required(ErrorMessage = "Een wachtwoord is vereist")]
        [StringLength(
            254,
            ErrorMessage = "Het wachtwoord moet minstens 6 karakters lang zijn en maximaal 254",
            MinimumLength = 6
        )]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(
            "Password",
            ErrorMessage = "Het controle wachtwoord komt niet overeen met het wachtwoord"
        )]
        public string RepeatPassword { get; set; }

        //TODO: make confirm privacy thing + date + database work
    }
}
