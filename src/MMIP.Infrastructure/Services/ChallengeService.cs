using MMIP.Infrastructure.Repositories;
using MMIP.Shared.Entities;
using MMIP.Shared.Filters;
using MMIP.Shared.StateContainers;

namespace MMIP.Infrastructure.Services
{
    public class ChallengeService : BaseEntityService<Challenge>
    {
        private ChallengeRepository _challengeRepository = new();

        public ChallengeService(IRepository<Challenge> repository)
            : base(repository) { }

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
