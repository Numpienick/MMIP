using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MMIP.Infrastructure.Services;
using MMIP.Shared.Entities;
using MMIP.Shared.Filters;
using MMIP.Shared.StateContainers;
using System.Text.Json;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace MMIP.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengesController : Controller
    {
        private readonly ChallengeService _challengeService;

        public ChallengesController(ChallengeService challengeService) =>
            _challengeService = challengeService;

        [HttpPost]
        public async Task<IActionResult> CreateChallenge([FromBody] Challenge challenge)
        {
            // TODO: Remove this line when organizations are implemented
            // A hardcoded default organization is used for now
            challenge.OrganizationId = Guid.Parse("00000000-0000-0000-0000-000000000001");
            try
            {
                challenge.CurrentPhaseId = TempStateContainer.Instance().Phases.FirstOrDefault().Id;
                Console.WriteLine("Successfully created challenge: " + challenge.Title);
                await _challengeService.AddAsync(challenge);
                return Ok("Successfully created challenge: " + challenge.Title);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetChallenge(Guid id)
        {
            var result = await _challengeService.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetChallenges(string filterCriteria)
        {
            //TODO: Initialize phases for state container, remove this line later.
            _challengeService.GetPhases();
            ICriteria criteria = JsonSerializer.Deserialize<ICriteria>(filterCriteria);
            return Ok(_challengeService.GetChallenges(criteria));
        }

        [HttpPatch]
        public IActionResult UpdateChallenge(Challenge challenge)
        {
            _challengeService.UpdateChallenge(challenge);
            return Ok("Successfully updated challenge: " + challenge.Title);
        }

        [HttpDelete]
        public static IActionResult DeleteChallenge(Challenge challenge)
        {
            return null;
        }
    }
}
