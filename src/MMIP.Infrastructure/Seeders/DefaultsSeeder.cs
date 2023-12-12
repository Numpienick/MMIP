using Microsoft.EntityFrameworkCore;
using MMIP.Infrastructure.Context;
using MMIP.Infrastructure.Helpers;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Seeders;

public class DefaultsSeeder : IDatabaseSeeder
{
    private readonly ApplicationContext _context;

    public DefaultsSeeder(ApplicationContext context)
    {
        _context = context;
    }

    public async Task Initialize()
    {
        await _seedSectors();
        await _seedDefaultOrganization();
    }

    private async Task _seedDefaultOrganization()
    {
        var orgId = Guid.Parse("00000000-0000-0000-0000-000000000001");
        if (await _doesEntityExist<Organization>(orgId))
            return;

        var sectorId = (await _context.Sectors.FirstOrDefaultAsync())?.Id;
        if (sectorId == default)
            await _seedSectors();

        sectorId = (await _context.Sectors.FirstOrDefaultAsync())!.Id;

        var org = new Organization
        {
            Id = orgId,
            Name = "Default Organization",
            EnrollmentCode = EnrollmentCodeGenerator.GenerateEnrollmentCode(),
            SectorId = sectorId.Value
        };
        await _context.Organizations.AddAsync(org);
        await _context.SaveChangesAsync();
    }

    private async Task _seedSectors()
    {
        var sectors = new List<Sector>()
        {
            new() { Id = Guid.NewGuid(), Name = "Gezondheidszorg en -welzijn" },
            new() { Id = Guid.NewGuid(), Name = "Handel en dienstverlening" },
            new() { Id = Guid.NewGuid(), Name = "ICT" },
            new() { Id = Guid.NewGuid(), Name = "Milieu en Agrarische sector" },
            new() { Id = Guid.NewGuid(), Name = "Media en communicatie" },
            new() { Id = Guid.NewGuid(), Name = "Onderwijs, cultuur en wetenschap" },
            new() { Id = Guid.NewGuid(), Name = "Techniek, productie en bouw" },
            new() { Id = Guid.NewGuid(), Name = "Toerisme, recreatie en horeca" },
            new() { Id = Guid.NewGuid(), Name = "Transport en logistiek" },
        };

        foreach (var sector in sectors)
        {
            if (await _doesEntityExist<Sector>(sector.Id))
                continue;
            await _context.Sectors.AddAsync(sector);
        }

        await _context.SaveChangesAsync();
    }

    private async Task<bool> _doesEntityExist<TEntity>(Guid id)
        where TEntity : BaseEntity => await _context.Set<TEntity>().FindAsync(id) != null;
}
