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
        var testOrganizations = new List<string>()
        {
            "InnoMatch",
            "Sparky",
            "Greenify",
            "Zappo",
            "Flexi",
            "Lingo",
            "Vibe",
            "Bloom",
            "Solve",
            "Fynd",
            "Pluto",
            "Nura",
            "Coco",
            "Rise",
            "Milo",
            "Zeno",
            "Lumi",
            "Nova",
            "Yolo",
            "Breezy",
        };

        var sector = await _context.Sectors.FirstOrDefaultAsync();
        if (sector == default)
        {
            await _sectorSeeder.Seed();
            sector = await _context.Sectors.FirstAsync();
        }

        for (int i = 0; i < amount; i++)
        {
            var orgProfile = new OrganizationProfile
            {
                AvatarPath = $"https://picsum.photos/seed/{new Random().Next(999999)}/400/400",
                Description = $"Default Organization Description {i}",
                BannerImagePath = $"https://picsum.photos/seed/{new Random().Next(999999)}/1600/888"
            };

            organizations.Add(
                new Organization
                {
                    Name = testOrganizations[i],
                    EnrollmentCode = EnrollmentCodeGenerator.GenerateEnrollmentCode(),
                    Sector = sector,
                    Profile = orgProfile,
                }
            );
        }

        await _context.Organizations.AddRangeAsync(organizations);
        await _context.SaveChangesAsync();
    }
}
