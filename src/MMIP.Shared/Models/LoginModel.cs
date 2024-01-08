using System.ComponentModel.DataAnnotations;

namespace MMIP.Shared.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Een e-mailadres is vereist")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Een wachtwoord is vereist")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
