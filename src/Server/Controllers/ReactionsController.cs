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
    public class ReactionsController : Controller
    {
        ReactionService _reactionService { get; set; }
        ChallengeService _challengeService { get; set; }

        public ReactionsController(
            ReactionService reactionService,
            ChallengeService challengeService
        )
        {
            _reactionService = reactionService;
            _challengeService = challengeService;
        }

        [HttpPost]
        public IActionResult CreateReaction([FromBody] Reaction reaction)
        {
            try
            {
                _reactionService.CreateReaction(reaction);
                return Ok("Successfully created reaction");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetReaction(Guid id)
        {
            return Ok(_reactionService.GetReaction(id));
        }

        // TODO: Get reactions from specific challenge.
        [HttpGet]
        public IActionResult GetReactions(Guid challengeId)
        {
            //Challenge challenge = _challengeService.GetChallenge(challengeId);
            //return Ok(_reactionService.GetReactions().Where(r => r.Id == challengeId));
            return Ok(_reactionService.GetReactions());
        }
    }
}
