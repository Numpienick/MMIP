﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ChallengeService _challengeService;

        public ChallengesController(ChallengeService challengeService)
        {
            _challengeService = challengeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateChallenge([FromBody] Challenge challenge)
        {
            // TODO: Remove this line when organizations are implemented
            // A hardcoded default organization is used for now
            challenge.OrganizationId = Guid.Parse("00000000-0000-0000-0000-000000000001");
            try
            {
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
            ICriteria criteria = JsonSerializer.Deserialize<ICriteria>(filterCriteria);
            return Ok(_challengeService.GetChallenges(criteria));
        }

        [HttpGet("overview")]
        public async Task<IActionResult> GetChallengesOverview(int take, int skip)
        {
            var view = await _challengeService.GetCardViewsAsync(take, skip);
            if (view.Any())
                return Ok(view);

            return Empty;
        }

        //[HttpGet("phases/{id:guid}")]
        //public async Task<IActionResult> GetChallengePhases(Guid id)
        //{
        //    var result = await _phaseSerivce.GetByIdAsync(id);
        //    if (result == null)
        //        return NotFound();
        //    return Ok(result);
        //}

        [HttpPatch]
        public IActionResult UpdateChallenge(Challenge challenge)
        {
            return Ok("Successfully updated challenge: " + challenge.Title);
        }

        [HttpDelete]
        public static IActionResult DeleteChallenge(Challenge challenge)
        {
            return null;
        }
    }
}
