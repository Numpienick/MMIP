using MMIP.Infrastructure.Seeders.EntitySeeders;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Seeders;

public class RandomDataSeeder : IDatabaseSeeder
{
    private readonly IEntitySeeder<Organization> _organizationSeeder;
    private readonly IEntitySeeder<Challenge> _challengeSeeder;

    public RandomDataSeeder(
        IEntitySeeder<Organization> organizationSeeder,
        IEntitySeeder<Challenge> challengeSeeder
    )
    {
        _organizationSeeder = organizationSeeder;
        _challengeSeeder = challengeSeeder;
    }

    public async Task Initialize()
    {
        await _organizationSeeder.Seed(1);
        await _challengeSeeder.Seed(9);
    }
}
