using AutoMapper;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using MMIP.Infrastructure.Context;
using MMIP.Infrastructure.Models.Identity;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Services
{
    //TODO: Work in progress
    public class UserService : IProfileService
    {
        //// https://stackoverflow.com/questions/63003540/how-do-i-add-end-user-self-registration-to-identityserver/77401550#77401550
        //private readonly ApplicationContext _dbContext;
        //private readonly UserManager<User> _userManager;
        //private readonly IMapper _mapper;

        //public UserService(ApplicationContext dbContext, UserManager<User> userManager, IMapper mapper)
        //{
        //    _dbContext = dbContext;
        //    _userManager = userManager;
        //    _mapper = mapper;
        //}

        //public async Task<string> CreateUserAsync(User newUser)
        //{
        //    if (newUser.Email != null && await _userManager.FindByEmailAsync(newUser.Email) == null)
        //    {
        //        AppUser appModel = _mapper.Map<AppUser>(newUser);
        //        User newAppUser = _mapper.Map<User>(appModel);
        //        newAppUser.UserName = newUser.UserName;

        //        IdentityResult result = await _userManager.CreateAsync(newAppUser, newUser.Password);

        //        if (result.Succeeded)
        //        {
        //            return "User is created";
        //        }
        //        else
        //        {
        //            return "There was a problem with the user creation";
        //        }
        //    }
        //    return "This E-mail is already being used";
        //}

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
    }
}
