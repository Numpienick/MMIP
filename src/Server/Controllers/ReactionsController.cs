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
        ReactionService _reactionService = new ReactionService();
        ChallengeService _challengeService = new ChallengeService();

        public ReactionsController() { }

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
