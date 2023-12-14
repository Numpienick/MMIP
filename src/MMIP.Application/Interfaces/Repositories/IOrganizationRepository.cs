using MMIP.Shared.Entities;

namespace MMIP.Application.Interfaces.Repositories;

public interface IOrganizationRepository
{
    public Task<List<Challenge>> GetChallengesAsync(Guid id);
}
