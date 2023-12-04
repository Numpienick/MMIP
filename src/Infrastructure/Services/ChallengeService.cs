using Infrastructure.Repositories;
using Shared.Entities;
using Shared.Filters;
using Shared.StateContainers;

namespace Infrastructure.Services
{
    public class ChallengeService : BaseEntityService
    {
        private ChallengeRepository _challengeRepository = new ChallengeRepository();

        public bool CreateChallenge(Challenge challenge)
        {
            try
            {
                _challengeRepository.Create(challenge);
                if (TempStateContainer.Instance().Challenges == null)
                {
                    var challenges = _challengeRepository.GetAll();
                    TempStateContainer.Instance().Challenges = challenges.Result;
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return false;
        }

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
