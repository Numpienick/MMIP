using Microsoft.AspNetCore.Mvc;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengesController
    {
        [HttpPost]
        public IActionResult CreateChallenge([FromBody] Challenge challenge)
        {
            try
            {
                Console.WriteLine("Succesfully created challenge: " + challenge.Title.Value);
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
