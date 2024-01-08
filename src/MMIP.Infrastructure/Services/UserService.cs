using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using MMIP.Application.Interfaces.Repositories;
using MMIP.Infrastructure.Context;
using MMIP.Shared.Entities;
using MMIP.Shared.Models;

namespace MMIP.Infrastructure.Services
{
    public class UserService : IProfileService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> CreateUserAsync(UserModel userModel)
        {
            if (await _userManager.FindByEmailAsync(userModel.Email) == null)
            {
                var user = new User
                {
                    Email = userModel.Email,
                    UserName = userModel.Email,
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Preposition = userModel.Preposition,
                    Description = userModel.Description,
                    AvatarPath = userModel.AvatarPath,
                    AgreedToPrivacy = userModel.AgreedToPrivacy,
                    AgreedToPrivacyOn = DateTimeOffset.Now
                };

                IdentityResult result = await _userManager.CreateAsync(user, userModel.Password);

                if (result.Succeeded)
                {
                    return "User is created";
                }
                return "There was a problem with the user creation";
            }
            return "This E-mail is already being used";
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            throw new NotImplementedException();
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            throw new NotImplementedException();
        }
    }
}
