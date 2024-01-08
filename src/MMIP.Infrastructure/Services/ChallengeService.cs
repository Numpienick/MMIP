using MMIP.Application.Interfaces.Repositories;
using MMIP.Shared.Entities;
using MMIP.Shared.Filters;
using MMIP.Shared.Views;

namespace MMIP.Infrastructure.Services
{
    public class ChallengeService : BaseEntityService<Challenge>
    {
        private readonly IChallengeRepository _repository;
        private readonly IUnitOfWork _unitOfWork; // TODO: TEMP remove this when phases work

        public ChallengeService(IUnitOfWork unitOfWork, IChallengeRepository repository)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public override Task AddAsync(Challenge entity)
        {
            var random = new Random();
            entity.BannerImagePath = $"https://picsum.photos/seed/{random.Next(1024)}/556/200";

            // TODO: TEMP remove this section when phases work
            var phaseRepo = _unitOfWork.Repository<Phase>();
            entity.Phases = new List<Phase>() { phaseRepo.Entities.First() };
            entity.CurrentPhaseId = entity.Phases.First().Id;

            return base.AddAsync(entity);
        }

        // TODO: Filter challenges based on filter criteria.
        public IEnumerable<Challenge> GetChallenges(ICriteria filterCriteria)
        {
            throw new NotImplementedException();
        }

        public Task<ChallengeView?> GetChallengeViewAsync(Guid id)
        {
            return _repository.GetChallengeViewAsync(id);
        }

        public Task<List<ChallengeCardView>> GetCardViewsAsync(int take, int skip)
        {
            int pageNumber = skip / take;
            return _repository.GetChallengeCardsAsync(pageNumber, take);
        }

        public Task<List<ChallengeCardView>> GetCarouselAsync(int take)
        {
            return _repository.GetCarouselAsync(take);
        }
    }
}
