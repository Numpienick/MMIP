using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MMIP.Infrastructure.Services;
using MMIP.Shared.Entities;

namespace MMIP.Server.Controllers
{
    // TODO: check attributes and functionality -> work in progress
    //[Authorize] // -> To specify that this class requires specific authorization
    //[AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        //[AllowAnonymous]
        public async Task<ActionResult<string>> CreateUser([FromBody] User newUser)
        {
            if (newUser.Email != null)
            {
                string result = await _userService.CreateUserAsync(newUser);
                return Ok(result);
            }
            return BadRequest("E-mail is missing");
        }

        //private readonly UserManager<User> _userManager;

        //public UserController(UserManager<User> userManager)
        //{
        //    this._userManager = userManager;
        //}
    }
}
