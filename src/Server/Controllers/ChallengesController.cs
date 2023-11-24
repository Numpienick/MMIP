using Microsoft.AspNetCore.Mvc;
using Shared.Entities;
using Shared.Filters;
using Shared.StateContainers;
using Infrastructure.Services;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengesController : Controller
    {
        private ChallengeService _challengeService = new ChallengeService();

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
        public IActionResult GetChallenge(Guid id)
        {
            return Ok(_challengeService.GetChallenge(id));
        }

        [HttpGet]
        public IActionResult GetChallenges([FromQuery] string filterCriteria)
        {
            ICriteria criteria = JsonSerializer.Deserialize<ICriteria>(filterCriteria);
            return Ok(_challengeService.GetChallenges(criteria));
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
