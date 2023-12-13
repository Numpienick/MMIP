using Microsoft.EntityFrameworkCore;
using MMIP.Application.Interfaces;
using MMIP.Infrastructure.Context;
using MMIP.Shared.Entities;
using MMIP.Shared.Enums;

namespace MMIP.Infrastructure.Seeders.EntitySeeders;

public class RandomChallengeSeeder : IEntitySeeder<Challenge>
{
    private readonly ApplicationContext _context;
    private readonly IEntitySeeder<Organization> _organizationSeeder;

    public RandomChallengeSeeder(
        ApplicationContext context,
        IEntitySeeder<Organization> organizationSeeder
    )
    {
        _context = context;
        _organizationSeeder = organizationSeeder;
    }

    public async Task Seed(int amount = 1)
    {
        var challenges = new List<Challenge>();
        var random = new Random();
        var visibilityValues = Enum.GetValues<Visibility>();
        var allOrganizations = (await _getOrganizations(random.Next(1, 5))).ToList();
        var allTags = (await _getTags(random.Next(1, 20))).ToArray();
        var allPhases = (await _getPhases(4)).ToArray();

        for (int i = 0; i < amount; i++)
        {
            var phases = allPhases.Take(random.Next(1, allPhases.Length)).ToList();
            var visibility = (Visibility)(
                visibilityValues.GetValue(random.Next(visibilityValues.Length))
                ?? Visibility.VisibleToAll
            );
            var organizationId = allOrganizations[random.Next(allOrganizations.Count)].Id;
            var currentPhaseId = phases[random.Next(phases.Count)].Id;
            var tags = allTags.Take(random.Next(allTags.Length)).ToList();

            challenges.Add(
                new Challenge
                {
                    Title = $"Challenge {i}",
                    Description = $"Description {i}",
                    ShortDescription = $"Short description {i}",
                    Deadline = DateTime.Now.AddDays(10),
                    ChallengeVisibility = visibility,
                    BannerImagePath = $"https://picsum.photos/seed/{i}/556/200",
                    FinalReport = $"Final report {i}",
                    StartDate = DateTime.Now,
                    OrganizationId = organizationId,
                    CurrentPhaseId = currentPhaseId,
                    Tags = tags,
                    Phases = phases,
                }
            );
        }

        await _context.Challenges.AddRangeAsync(challenges);
        await _context.SaveChangesAsync();
    }

    private async Task<IEnumerable<Organization>> _getOrganizations(int amount)
    {
        var orgs = await _context.Organizations.Take(amount).ToListAsync();
        if (orgs.Count >= amount)
            return orgs;

        await _organizationSeeder.Seed(amount - orgs.Count);
        orgs.AddRange(_context.Organizations.Take(amount));

        return orgs;
    }

    private async Task<IEnumerable<Tag>> _getTags(int amount)
    {
        var tags = await _context.Tags.Take(amount).ToListAsync();
        if (tags.Count >= amount)
            return tags;
        for (int i = 0; i < amount - tags.Count; i++)
        {
            tags.Add(new Tag { Value = "Tag12345681234 " + i });
        }

        return tags;
    }

    private async Task<IEnumerable<Phase>> _getPhases(int amount)
    {
        var phases = await _context.Phases.Take(amount).ToListAsync();
        if (phases.Count >= amount)
            return phases;
        for (int i = 0; i < amount - phases.Count; i++)
        {
            phases.Add(
                new Phase
                {
                    Id = Guid.NewGuid(),
                    Name = "Phase " + i,
                    Order = i + 1,
                    Description = "Description " + i,
                }
            );
        }

        return phases;
    }
}
