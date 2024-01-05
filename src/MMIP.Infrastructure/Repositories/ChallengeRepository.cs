using Microsoft.EntityFrameworkCore;
using MMIP.Application.Interfaces.Repositories;
using MMIP.Shared.Entities;
using MMIP.Shared.Enums;
using MMIP.Shared.Views;

namespace MMIP.Infrastructure.Repositories
{
    internal class ChallengeRepository : IChallengeRepository
    {
        private readonly IDataRepository<Challenge> _repository;
        private readonly IDataRepository<ChallengeView> _viewRepository;
        private readonly IDataRepository<ChallengeCardView> _cardViewRepository;

        public ChallengeRepository(
            IDataRepository<Challenge> repository,
            IDataRepository<ChallengeView> viewRepository,
            IDataRepository<ChallengeCardView> cardViewRepository
        )
        {
            _repository = repository;
            _viewRepository = viewRepository;
            _cardViewRepository = cardViewRepository;
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

        public Task<List<ChallengeCardView>> GetCarouselAsync()
        {
            return _cardViewRepository.Entities
                .Where(cv => cv.ChallengeVisibility == Visibility.VisibleToAll)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
