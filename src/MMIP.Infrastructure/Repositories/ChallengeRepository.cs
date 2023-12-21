using MMIP.Application.Interfaces.Repositories;
using MMIP.Shared.Entities;
using MMIP.Shared.Views;

namespace MMIP.Infrastructure.Repositories
{
    internal class ChallengeRepository : IChallengeRepository
    {
        private readonly IDataRepository<Challenge> _repository;

        public ChallengeRepository(IDataRepository<Challenge> repository)
        {
            _repository = repository;
        }

        public Task<List<ChallengeCardView>> GetChallengeCardsAsync(int pageNumber, int pageSize)
        {
            return _repository.GetPagedResponseAsync<ChallengeCardView>(pageNumber, pageSize);
        }
    }
}
