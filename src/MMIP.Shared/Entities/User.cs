using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MMIP.Shared.Entities
{
    public class User : IdentityUser
    {
        public string Description { get; set; }

        public string? AvatarPath { get; set; }

        [Required(ErrorMessage = "Required")]
        public string FirstName { get; set; }

        public string[]? Prefixes { get; set; }

        [Required(ErrorMessage = "Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)] //? maybe
        public string Password { get; set; }

        [Compare(
            "Password",
            ErrorMessage = "The comfirmation password does not match with the password"
        )]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }
    }
}
