using MMIP.Application.Interfaces.Repositories;
using MMIP.Infrastructure.Helpers;
using MMIP.Shared.Entities;
using MMIP.Shared.Projections;

namespace MMIP.Infrastructure.Services
{
    public class OrganizationService : BaseEntityService<Organization>
    {
        private readonly IOrganizationRepository _repository;

        public OrganizationService(IUnitOfWork unitOfWork, IOrganizationRepository repository)
            : base(unitOfWork)
        {
            _repository = repository;
        }

        public override Task AddAsync(Organization entity)
        {
            entity.EnrollmentCode = EnrollmentCodeGenerator.GenerateEnrollmentCode();
            return base.AddAsync(entity);
        }

        public Task<List<Challenge>> GetChallenges(Guid id)
        {
            return _repository.GetChallengesAsync(id);
        }

        public Task<List<OrganizationCarouselItemProjection>> GetCarouselAsync(int take)
        {
            return _repository.GetCarouselAsync(take);
        }
    }
}
