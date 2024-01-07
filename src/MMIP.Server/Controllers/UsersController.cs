using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MMIP.Infrastructure.Services;
using MMIP.Shared.Entities;
using MMIP.Shared.Models;

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

        [HttpPost]
        //[AllowAnonymous]
        public async Task<ActionResult<string>> CreateUser([FromBody] UserModel userModel)
        {
            if (userModel.Email != null)
            {
                string result = await _userService.CreateUserAsync(userModel);
                return Ok(result);
            }
            return BadRequest("E-mail is missing");
        }

        //[HttpGet("{email:string}")]
        //public async Task<IActionResult> GetUser(string email)
        //{
        //    var result = await _userService.GetByEmailAsync(email);
        //    if (result == null)
        //        return NotFound();
        //    return Ok(result);
        //}
    }
}
