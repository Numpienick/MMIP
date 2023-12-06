using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MMIP.Shared.Entities
{
    public class User : IdentityUser, IProfile
    {
        private List<string> _tags;

        public List<string> Tags
        {
            get => _tags;
            set => _tags = value;
        }

        public string Description { get; set; }

        public string? AvatarPath { get; set; }

        [Required(ErrorMessage = "Required")] public string FirstName { get; set; }

        public string[]? Prefixes { get; set; }

        [Required(ErrorMessage = "Required")] public string LastName { get; set; }

        [Required(ErrorMessage = "Required")] public string Email { get; set; }

        [Required(ErrorMessage = "Required")] public string Password { get; set; }

        [Compare(
            "Password",
            ErrorMessage = "The comfirmation password does not match with the password"
        )]
        public string RepeatPassword { get; set; }

        public string FullName()
        {
            string fullName = FirstName + " " + Prefixes + " " + LastName;
            return fullName;
        }

        public string[] GetTags()
        {
            string[] placeHolder = { "Test", "Test2" };
            return placeHolder;
        }
    }
}
