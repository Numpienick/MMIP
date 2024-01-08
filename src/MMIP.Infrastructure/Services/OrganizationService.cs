using MMIP.Application.Interfaces.Repositories;
using MMIP.Infrastructure.Helpers;
using MMIP.Shared.Entities;
using MMIP.Shared.Views;
using MMIP.Shared.Projections;

namespace MMIP.Infrastructure.Services
{
    public class OrganizationService : BaseEntityService<Organization>
    {
        private readonly IOrganizationRepository _repository;
        private readonly IChallengeRepository _challengeRepository;

        public OrganizationService(
            IUnitOfWork unitOfWork,
            IOrganizationRepository repository,
            IChallengeRepository challengeRepository
        )
            : base(unitOfWork)
        {
            _repository = repository;
            _challengeRepository = challengeRepository;
        }

        public override Task AddAsync(Organization entity)
        {
            entity.EnrollmentCode = EnrollmentCodeGenerator.GenerateEnrollmentCode();
            return base.AddAsync(entity);
        }

        public Task<List<ChallengeCardView>> GetChallengesOverviewAsync(Guid id, int take, int skip)
        {
            return _challengeRepository.GetChallengesOverviewOfOrganization(id, take, skip);
        }

        public Task<OrganizationProfile?> GetProfileAsync(Guid id)
        {
            return _repository.GetProfileAsync(id);
        }

        public Task<List<OrganizationCarouselItemProjection>> GetCarouselAsync(int take)
        {
            return _repository.GetCarouselAsync(take);
        }
    }
}
