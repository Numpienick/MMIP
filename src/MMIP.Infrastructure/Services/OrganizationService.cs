using MMIP.Application.Interfaces.Repositories;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Services
{
    public class OrganizationService : BaseEntityService<Organization>
    {
        public OrganizationService(IUnitOfWork unitOfWork)
            : base(unitOfWork) { }
    }
}
