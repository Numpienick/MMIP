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

    public async Task<OrganizationProfile?> GetProfileAsync(Guid id)
    {
        return await _repository.Entities
            .Where(o => o.Id == id)
            .Include(o => o.Profile)
            .Include(o => o.Sector)
            .Include(o => o.Tags)
            .ProjectTo<OrganizationProfile>(_mapper.ConfigurationProvider)
            .AsNoTracking()
            .SingleOrDefaultAsync();
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
