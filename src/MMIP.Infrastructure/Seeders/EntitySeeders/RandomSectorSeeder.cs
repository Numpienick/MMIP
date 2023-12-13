using MMIP.Application.Interfaces;
using MMIP.Infrastructure.Context;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Seeders.EntitySeeders;

public class RandomSectorSeeder : IEntitySeeder<Sector>
{
    private readonly ApplicationContext _context;

    public RandomSectorSeeder(ApplicationContext context)
    {
        _context = context;
    }

    public async Task Seed(int amount = 4)
    {
        var sectors = new List<Sector>();
        for (int i = 0; i < amount; i++)
        {
            sectors.Add(new Sector { Name = $"Sector {i}" });
        }

        await _context.AddRangeAsync(sectors);
        await _context.SaveChangesAsync();
    }
}
