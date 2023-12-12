using MMIP.Infrastructure.Context;
using MMIP.Infrastructure.Helpers;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Seeders.EntitySeeders;

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
            orgs.Add(
                new Organization
                {
                    Name = $"Organization {i}",
                    EnrollmentCode = EnrollmentCodeGenerator.GenerateEnrollmentCode(),
                    // TODO: Add sector id
                }
            );
        }

        await _context.Organizations.AddRangeAsync(orgs);
        await _context.SaveChangesAsync();
    }
}
