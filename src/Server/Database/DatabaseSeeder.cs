using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using Shared.Enums;

namespace Server.Database;

internal class DatabaseSeeder
{
    private readonly ApplicationContext _context;

    public DatabaseSeeder(ApplicationContext context)
    {
        _context = context;
    }

    public async Task Seed()
    {
        await _seedOrganizations();
        await _seedChallenges(10);
        await _context.SaveChangesAsync();
    }

    private async Task _seedOrganizations(int amount = 1)
    {
        var organizations = new List<Organization>();
        for (int i = 0; i < amount; i++)
        {
            organizations.Add(new Organization { Name = $"Organization {i}", });
        }

        await _context.Organizations.AddRangeAsync(organizations);
        await _context.SaveChangesAsync();
    }

    private async Task _seedChallenges(int amount = 1)
    {
        var challenges = new List<Challenge>();
        var rnd = new Random();
        var visibilityValues = Enum.GetValues<Visibility>();
        var existingOrgs = await _context.Organizations.ToArrayAsync();
        if (!existingOrgs.Any())
        {
            await _seedOrganizations(1);
            existingOrgs = await _context.Organizations.ToArrayAsync();
        }

        var exisitingTags = await _context.Tags.ToListAsync();
        if (!exisitingTags.Any())
        {
            for (int i = 0; i < rnd.Next(1, 20); i++)
            {
                exisitingTags.Add(new Tag { Value = "Tag " + i });
            }
        }

        var existingPhases = await _context.Phases.ToListAsync();
        if (!existingPhases.Any())
        {
            for (int i = 0; i < 4; i++)
            {
                existingPhases.Add(
                    new Phase
                    {
                        Name = "Phase " + i,
                        Order = i + 1,
                        Description = "Description " + i,
                    }
                );
            }
        }

        for (int i = 0; i < amount; i++)
        {
            var phases = existingPhases.Take(rnd.Next(1, existingPhases.Count)).ToList();
            var visibility = (Visibility)(
                visibilityValues.GetValue(rnd.Next(visibilityValues.Length))
                ?? Visibility.VisibleToAll
            );
            var organizationId = existingOrgs[rnd.Next(existingOrgs.Length)].Id;
            var currentPhaseId = phases[rnd.Next(phases.Count)].Id;
            var tags = exisitingTags.Take(rnd.Next(exisitingTags.Count)).ToList();

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
}
