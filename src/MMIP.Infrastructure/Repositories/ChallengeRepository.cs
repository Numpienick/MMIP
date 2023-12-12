using MMIP.Application.Interfaces.Repositories;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Repositories
{
    internal class ChallengeRepository : IChallengeRepository
    {
        private readonly IDataRepository<Challenge> _repository;

        public ChallengeRepository(IDataRepository<Challenge> repository)
        {
            _repository = repository;
        }
    }
}
