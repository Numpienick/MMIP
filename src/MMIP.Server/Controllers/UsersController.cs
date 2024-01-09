using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MMIP.Infrastructure.Services;
using MMIP.Shared.Entities;
using MMIP.Shared.Models;

namespace MMIP.Server.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UsersController(
            UserService userService,
            UserManager<User> userManager,
            SignInManager<User> signInManager
        )
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Route("users/register")]
        public async Task<ActionResult<string>> CreateUser([FromBody] UserModel userModel)
        {
            if (userModel.Email != null)
            {
                string result = await _userService.CreateUserAsync(userModel);
                return Ok(result);
            }
            return BadRequest("E-mail is missing");
        }

        [HttpPost]
        [Route("users/login")]
        public async Task<ActionResult> LoginUser([FromBody] LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user != null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(
                    user.Email,
                    loginModel.Password,
                    false,
                    false
                );
                if (signInResult.Succeeded)
                    return Ok("Succesfully logged-in");
            }
            return BadRequest("No existing user found");
        }
    }
}
