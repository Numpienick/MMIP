using Microsoft.EntityFrameworkCore;
using MMIP.Application.Interfaces.Repositories;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Repositories;

internal class OrganizationRepository : IOrganizationRepository
{
    private readonly IDataRepository<Organization> _repository;

    public OrganizationRepository(IDataRepository<Organization> repository)
    {
        _repository = repository;
    }

    public async Task<List<Challenge>> GetChallengesAsync(Guid id)
    {
        var result =
            await _repository.Entities
                .Include(o => o.Challenges)
                .Where(o => o.Id == id)
                .Select(o => o.Challenges)
                .SingleOrDefaultAsync() ?? Enumerable.Empty<Challenge>();
        return result.ToList();
    }
}
