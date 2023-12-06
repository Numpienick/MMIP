using Infrastructure.Context;
using Shared.Entities;

namespace Infrastructure.Seeders.EntitySeeders;

public class OrganizationSeeder : IEntitySeeder<Organization>
{
    private readonly ApplicationContext _context;

    public OrganizationSeeder(ApplicationContext context)
    {
        _context = context;
    }

    public async Task Seed(int amount = 1)
    {
        var orgs = new List<Organization>();
        for (int i = 0; i < amount; i++)
        {
            orgs.Add(new Organization { Name = $"Organization {i}", });
        }

        await _context.Organizations.AddRangeAsync(orgs);
        await _context.SaveChangesAsync();
    }
}
