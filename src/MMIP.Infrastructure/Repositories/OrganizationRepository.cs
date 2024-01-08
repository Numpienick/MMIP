using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MMIP.Application.Interfaces.Repositories;
using MMIP.Shared.Entities;
using MMIP.Shared.Projections;

namespace MMIP.Infrastructure.Repositories;

internal class OrganizationRepository : IOrganizationRepository
{
    private readonly IDataRepository<Organization> _repository;
    private readonly IMapper _mapper;

    public OrganizationRepository(IDataRepository<Organization> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
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

    public Task<List<OrganizationCarouselItemProjection>> GetCarouselAsync(int take)
    {
        return _repository.Entities
            .Include(o => o.Profile)
            .Take(take)
            .ProjectTo<OrganizationCarouselItemProjection>(_mapper.ConfigurationProvider)
            .AsNoTracking()
            .ToListAsync();
    }
}
