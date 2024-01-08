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
        private readonly IDataRepository<ChallengeCardView> _overviewRepository;

        public ChallengeRepository(
            IDataRepository<Challenge> repository,
            IDataRepository<ChallengeView> viewRepository,
            IDataRepository<ChallengeCardView> overviewRepository
        )
        {
            _repository = repository;
            _viewRepository = viewRepository;
            _overviewRepository = overviewRepository;
        }

        public Task<List<ChallengeCardView>> GetChallengeCardsAsync(int pageNumber, int pageSize)
        {
            return _overviewRepository.GetPagedResponseAsync(pageNumber, pageSize);
        }

        public Task<ChallengeView?> GetChallengeViewAsync(Guid id)
        {
            return _viewRepository.Entities.FirstOrDefaultAsync(cv => cv.ChallengeId == id);
        }

        public Task<List<ChallengeCardView>> GetChallengesOverviewOfOrganization(
            Guid orgId,
            int take,
            int skip
        )
        {
            return _overviewRepository.Entities
                .Where(cc => cc.OrganizationId == orgId)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public Task<List<ChallengeCardView>> GetCarouselAsync(int take)
        {
            return _overviewRepository.Entities
                .Where(cv => cv.ChallengeVisibility == Visibility.VisibleToAll)
                .Take(take)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
