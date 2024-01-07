using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MMIP.Application.Interfaces.Repositories;
using MMIP.Shared.Entities;

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
}
