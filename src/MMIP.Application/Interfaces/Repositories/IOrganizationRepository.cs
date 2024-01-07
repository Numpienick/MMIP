using MMIP.Shared.Entities;

namespace MMIP.Application.Interfaces.Repositories;

public interface IOrganizationRepository
{
    public Task<OrganizationProfile?> GetProfileAsync(Guid id);
}
