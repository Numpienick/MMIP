using Infrastructure.Repositories;
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
            return (Challenge)_challengeRepository.GetById(id);
        }

        // TODO: Filter challenges based on filter criteria.
        public IEnumerable<Challenge> GetChallenges(ICriteria filterCriteria)
        {
            IEnumerable<Challenge> challenges =
                (IEnumerable<Challenge>)_challengeRepository.GetAll();

            if (TempStateContainer.Instance().Challenges == null)
            {
                TempStateContainer.Instance().Challenges = challenges;
            }

            return TempStateContainer.Instance().Challenges;
        }

        public void UpdateChallenge(Challenge challenge) { }

        public void DeleteChallenge(Challenge challenge) { }
    }
}
