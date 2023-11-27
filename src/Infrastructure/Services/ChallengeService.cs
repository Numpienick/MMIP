using Infrastructure.Repositories;
using Microsoft.AspNetCore.Components;
using Shared.Entities;
using Shared.Filters;
using Shared.StateContainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ChallengeService : BaseEntityService
    {
        private ChallengeRepository _challengeRepository = new ChallengeRepository();

        public void CreateChallenge() { }

        public Challenge GetChallenge(Guid id)
        {
            return _challengeRepository.GetById(id).Result;
        }

        // TODO: Filter challenges based on filter criteria.
        public IEnumerable<Challenge> GetChallenges(ICriteria filterCriteria)
        {
            if (TempStateContainer.Instance().Challenges == null)
            {
                var challenges = _challengeRepository.GetAll();
                TempStateContainer.Instance().Challenges = challenges.Result;
            }

            // TODO: Return this when TempStateContainer can be removed.
            //return _challengeRepository.GetAll().Result;

            return TempStateContainer.Instance().Challenges;
        }

        public void UpdateChallenge(Challenge challenge) { }

        public void DeleteChallenge(Challenge challenge) { }
    }
}
