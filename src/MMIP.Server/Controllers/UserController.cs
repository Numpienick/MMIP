using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MMIP.Shared.Entities;

namespace MMIP.Server.Controllers
{
    //[Authorize] // -> To specify that this class requires specific authorization
    [ApiController]
    public class UserController
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            this._userManager = userManager;
        }
    }
}
