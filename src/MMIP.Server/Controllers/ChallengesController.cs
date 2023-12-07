﻿using Microsoft.AspNetCore.Mvc;
using MMIP.Infrastructure.Services;
using MMIP.Shared.Entities;
using MMIP.Shared.Filters;
using System.Text.Json;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace MMIP.Server.Controllers
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
                return Ok("Successfully created challenge: " + challenge.Title);
            }
            catch (ArgumentException e)
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

        [HttpGet("challengeCardView")]
        public async Task<IActionResult> GetChallengeCardViews(int take, int skip)
        {
            var view = await _challengeService.GetCardViewsAsync(take, skip);
            if (view.Any())
                return Ok(view);

            return Empty;
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
