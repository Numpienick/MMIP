using MMIP.Application.Interfaces;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Seeders;

public class RandomDataSeeder : IDatabaseSeeder
{
    private readonly IEntitySeeder<Organization> _organizationSeeder;
    private readonly IEntitySeeder<Challenge> _challengeSeeder;
    private readonly IEntitySeeder<Sector> _sectorSeeder;
    private readonly IEntitySeeder<Comment> _commentSeeder;

    public RandomDataSeeder(
        IEntitySeeder<Organization> organizationSeeder,
        IEntitySeeder<Challenge> challengeSeeder,
        IEntitySeeder<Sector> sectorSeeder,
        IEntitySeeder<Comment> commentSeeder
    )
    {
        _organizationSeeder = organizationSeeder;
        _challengeSeeder = challengeSeeder;
        _sectorSeeder = sectorSeeder;
        _commentSeeder = commentSeeder;
    }

    public async Task Initialize()
    {
        await _sectorSeeder.Seed(4);
        await _organizationSeeder.Seed(1);
        await _challengeSeeder.Seed(9);
        await _commentSeeder.Seed(40);
    }
}
