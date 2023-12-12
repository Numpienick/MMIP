using MMIP.Application.Interfaces.Repositories;
using MMIP.Infrastructure.Helpers;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Services
{
    public class OrganizationService : BaseEntityService<Organization>
    {
        public OrganizationService(IUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        public override Task AddAsync(Organization entity)
        {
            entity.EnrollmentCode = EnrollmentCodeGenerator.GenerateEnrollmentCode();
            return base.AddAsync(entity);
        }
    }
}
