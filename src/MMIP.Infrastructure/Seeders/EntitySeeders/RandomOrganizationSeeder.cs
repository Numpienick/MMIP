using Microsoft.EntityFrameworkCore;
using MMIP.Application.Interfaces;
using MMIP.Infrastructure.Context;
using MMIP.Infrastructure.Helpers;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Seeders.EntitySeeders;

public class RandomOrganizationSeeder : IEntitySeeder<Organization>
{
    private readonly ApplicationContext _context;
    private readonly IEntitySeeder<Sector> _sectorSeeder;

    public RandomOrganizationSeeder(ApplicationContext context, IEntitySeeder<Sector> sectorSeeder)
    {
        _context = context;
        _sectorSeeder = sectorSeeder;
    }

    public async Task Seed(int amount = 1)
    {
        var organizations = new List<Organization>();
        var sectorId = await _context.Sectors.Select(s => s.Id).FirstOrDefaultAsync();
        if (sectorId == default)
        {
            await _sectorSeeder.Seed();
            sectorId = await _context.Sectors.Select(s => s.Id).FirstAsync();
        }

        for (int i = 0; i < amount; i++)
        {
            organizations.Add(
                new Organization
                {
                    Name = $"Organization {i}",
                    EnrollmentCode = EnrollmentCodeGenerator.GenerateEnrollmentCode(),
                    SectorId = sectorId
                }
            );
        }

        await _context.Organizations.AddRangeAsync(organizations);
        await _context.SaveChangesAsync();
    }
}
