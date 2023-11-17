using Infrastructure.Repositories;
using Shared.Entities;
using Shared.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ChallengeService : BaseEntityService
    {
        public void CreateChallenge() { }

        public Challenge GetChallenge(Guid id)
        {
            return null;
        }

        public IEnumerable<Challenge> GetChallenges(ICriteria filterCriteria)
        {
            return null;
        }

        public void UpdateChallenge(Challenge challenge) { }

        public void DeleteChallenge(Challenge challenge) { }
    }
}
