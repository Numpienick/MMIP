using Microsoft.AspNetCore.Mvc;
using Shared.Entities;
using System.Text.Json;
using Shared.Filters;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengesController
    {
        [HttpPost]
        public IActionResult CreateChallenge([FromBody] string json)
        {
            //TODO: doesn't work yet, investigate why it doesn't get here
            Challenge challenge = JsonSerializer.Deserialize<Challenge>(json);
            Console.WriteLine(challenge);
            try
            {
                Console.WriteLine("Succesfully created challenge: " + challenge.Title);
                return new OkResult();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new BadRequestResult();
            }
        }

        [HttpGet("{id}")]
        public static IActionResult GetChallenge(Guid id)
        {
            return null;
        }

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
