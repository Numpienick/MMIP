using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Filters;

namespace Server.Controllers
{
    [ApiController]
    public class ChallengeController
    {
        public IActionResult CreateChallenge()
        {
            return null;
        }

        public IActionResult GetChallenge(Guid id)
        {
            return null;
        }

        public IActionResult GetChallenges(ICriteria filterCriteria)
        {
            return null;
        }

        public IActionResult UpdateChallenge(Challenge challenge)
        {
            return null;
        }

        public IActionResult DeleteChallenge(Challenge challenge)
        {
            return null;
        }
    }
}
