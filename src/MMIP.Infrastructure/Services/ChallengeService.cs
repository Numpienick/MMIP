using MMIP.Application.Interfaces.Repositories;
using MMIP.Shared.Entities;
using MMIP.Shared.Filters;
using MMIP.Shared.Views;

namespace MMIP.Infrastructure.Services
{
    public class ChallengeService : BaseEntityService<Challenge>
    {
        private readonly IChallengeRepository _repository;

        public ChallengeService(IUnitOfWork unitOfWork, IChallengeRepository repository)
            : base(unitOfWork)
        {
            _repository = repository;
        }

        public override Task AddAsync(Challenge entity)
        {
            var random = new Random();
            entity.BannerImagePath = $"https://picsum.photos/seed/{random.Next(1024)}/556/200";
            return base.AddAsync(entity);
        }

        // TODO: Filter challenges based on filter criteria.
        public IEnumerable<Challenge> GetChallenges(ICriteria filterCriteria)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChallengeCardView>> GetCardViewsAsync(int take, int skip)
        {
            int pageNumber = skip / take;
            return _repository.GetChallengeCardsAsync(pageNumber, take);
        }
    }
}
