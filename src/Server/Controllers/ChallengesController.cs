using Microsoft.AspNetCore.Mvc;
using Shared.Entities;
using Shared.Filters;
using Shared.StateContainers;
using Infrastructure.Services;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Components;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengesController : Controller
    {
        private ChallengeService _challengeService { get; set; }

        public ChallengesController(ChallengeService challengeService) =>
            _challengeService = challengeService;

        [HttpPost]
        public IActionResult CreateChallenge([FromBody] Challenge challenge)
        {
            try
            {
                Console.WriteLine("Successfully created challenge: " + challenge.Title);
                _challengeService.CreateChallenge(challenge);
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
