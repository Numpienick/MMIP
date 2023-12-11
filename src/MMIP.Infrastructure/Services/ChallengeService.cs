using MMIP.Application.Interfaces.Repositories;
using MMIP.Shared.Entities;
using MMIP.Shared.Filters;

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

        // TODO: Filter challenges based on filter criteria.
        public IEnumerable<Challenge> GetChallenges(ICriteria filterCriteria)
        {
            throw new NotImplementedException();
        }
    }
}
