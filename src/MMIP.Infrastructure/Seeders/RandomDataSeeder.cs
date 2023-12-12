using MMIP.Application.Interfaces;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Seeders;

public class RandomDataSeeder : IDatabaseSeeder
{
    private readonly IEntitySeeder<Organization> _organizationSeeder;
    private readonly IEntitySeeder<Challenge> _challengeSeeder;
    private readonly IEntitySeeder<Sector> _sectorSeeder;

    public RandomDataSeeder(
        IEntitySeeder<Organization> organizationSeeder,
        IEntitySeeder<Challenge> challengeSeeder,
        IEntitySeeder<Sector> sectorSeeder
    )
    {
        _organizationSeeder = organizationSeeder;
        _challengeSeeder = challengeSeeder;
        _sectorSeeder = sectorSeeder;
    }

    public async Task Initialize()
    {
        await _sectorSeeder.Seed(4);
        await _organizationSeeder.Seed(1);
        await _challengeSeeder.Seed(9);
    }
}
