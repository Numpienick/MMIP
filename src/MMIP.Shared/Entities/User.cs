using Microsoft.AspNetCore.Identity;

namespace MMIP.Shared.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Preposition { get; set; }
        public string Description { get; set; } = null!;
        public string? FullName { get; set; }
        public override string? UserName => Email;
        public string? AvatarPath { get; set; }
        public bool AgreedToPrivacy { get; set; } = false;
        public DateTimeOffset AgreedToPrivacyDateTimeStamp { get; set; }
    }
}
