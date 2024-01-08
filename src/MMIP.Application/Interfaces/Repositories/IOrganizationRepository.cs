using MMIP.Shared.Entities;
using MMIP.Shared.Projections;

namespace MMIP.Application.Interfaces.Repositories;

public interface IOrganizationRepository
{
    public Task<List<Challenge>> GetChallengesAsync(Guid id);
    public Task<List<OrganizationCarouselItemProjection>> GetCarouselAsync(int take);
}
