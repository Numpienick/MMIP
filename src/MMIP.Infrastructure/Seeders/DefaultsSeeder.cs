using MMIP.Infrastructure.Context;
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
        await _seedDefaultOrganization();
    }

    private async Task _seedDefaultOrganization()
    {
        //var org = new Organization
        //{
        //    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
        //    Name = "Default Organization",
        //};
        //await _context.Organizations.AddAsync(org);
        await _context.SaveChangesAsync();
    }
}
