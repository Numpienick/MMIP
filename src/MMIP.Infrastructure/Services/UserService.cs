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
        private readonly IUserRepository _repository;

        public UserService(UserManager<User> userManager, IUserRepository repository)
        {
            _userManager = userManager;
            _repository = repository;
        }

        public async Task<string> CreateUserAsync(UserModel userModel)
        {
            if (
                userModel.Email != null
                && await _userManager.FindByEmailAsync(userModel.Email) == null
            )
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
                    AgreedToPrivacyDateTimeStamp = DateTime.Now
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

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            throw new NotImplementedException();
            //var nameClaim = context.Subject.FindAll(JwtClaimTypes.Name);

            //await Task.CompletedTask;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            throw new NotImplementedException();
            //await Task.CompletedTask;
        }

        //public async Task<User?> GetByEmailAsync(string email)
        //{
        //    return await _repository.GetUserAsync(email);
        //}
    }
}
