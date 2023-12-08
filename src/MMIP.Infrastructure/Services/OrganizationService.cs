using MMIP.Infrastructure.Repositories;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Services
{
    public class OrganizationService : BaseEntityService<Organization>
    {
        internal OrganizationService(IRepository<Organization> repository)
            : base(repository) { }
    }
}
