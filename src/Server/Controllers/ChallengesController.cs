using Microsoft.AspNetCore.Mvc;
using Shared.Entities;
using Shared.Filters;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengesController : Controller
    {
        [HttpPost]
        public IActionResult CreateChallenge([FromBody] Challenge challenge)
        {
            try
            {
                //TODO: handle it and put in the database
                Console.WriteLine("Sucscesfully created challenge: " + challenge.Title);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public static IActionResult GetChallenge(Guid id)
        {
            return null;
        }

        // TODO: Fill method.
        [HttpGet]
        public static IActionResult GetChallenges(ICriteria filterCriteria)
        {
            return null;
        }

        [HttpPatch]
        public static IActionResult UpdateChallenge(Challenge challenge)
        {
            return null;
        }

        [HttpDelete]
        public static IActionResult DeleteChallenge(Challenge challenge)
        {
            return null;
        }
    }
}
