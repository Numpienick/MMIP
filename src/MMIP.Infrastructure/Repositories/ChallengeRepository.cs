using Microsoft.EntityFrameworkCore;
using MMIP.Application.Interfaces.Repositories;
using MMIP.Shared.Entities;
using MMIP.Shared.Views;

namespace MMIP.Infrastructure.Repositories
{
    internal class ChallengeRepository : IChallengeRepository
    {
        private readonly IDataRepository<Challenge> _repository;
        private readonly IDataRepository<ChallengeView> _viewRepository;

        public ChallengeRepository(
            IDataRepository<Challenge> repository,
            IDataRepository<ChallengeView> viewRepository
        )
        {
            _repository = repository;
            _viewRepository = viewRepository;
        }

        public Task<List<ChallengeCardView>> GetChallengeCardsAsync(int pageNumber, int pageSize)
        {
            // TODO: Change to view repository
            return _repository.GetPagedResponseAsync<ChallengeCardView>(pageNumber, pageSize);
        }

        public Task<ChallengeView?> GetChallengeViewAsync(Guid id)
        {
            return _viewRepository.Entities.Where(cv => cv.ChallengeId == id).FirstOrDefaultAsync();
        }
    }
}
