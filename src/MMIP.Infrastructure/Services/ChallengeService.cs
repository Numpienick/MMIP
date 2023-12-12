using Microsoft.EntityFrameworkCore;
using MMIP.Infrastructure.Repositories;
using MMIP.Shared.Entities;
using MMIP.Shared.Filters;
using MMIP.Shared.StateContainers;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MMIP.Infrastructure.Services
{
    public class ChallengeService : BaseEntityService
    {
        private ChallengeRepository _challengeRepository = new ChallengeRepository();

        public void CreateChallenge(Challenge challenge)
        {
            try
            {
                _challengeRepository.Create(challenge);
                if (TempStateContainer.Instance().Challenges == null)
                {
                    var challenges = _challengeRepository.GetAll();
                    TempStateContainer.Instance().Challenges = challenges.Result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Challenge GetChallenge(Guid id)
        {
            return _challengeRepository.GetById(id).Result;
        }

        public IEnumerable<Phase> GetPhases()
        {
            if (TempStateContainer.Instance().Phases == null)
            {
                var phases = _challengeRepository.GetPhases();
                TempStateContainer.Instance().Phases = phases.Result;
            }

            return TempStateContainer.Instance().Phases;
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

        public void UpdateChallenge(Challenge challenge)
        {
            foreach (Challenge existingChallenge in TempStateContainer.Instance().Challenges)
            {
                if (existingChallenge.Id == challenge.Id)
                {
                    existingChallenge.Title = challenge.Title;
                }
            }
        }

        public void DeleteChallenge(Challenge challenge) { }
    }
}
