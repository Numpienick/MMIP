using Microsoft.EntityFrameworkCore;
using MMIP.Infrastructure.Services;
using MMIP.Test.Infrastructure.Stubs;

namespace MMIP.Test.Integration;

[Collection(nameof(ContextFixtureCollection))]
public class ChallengeTests
{
    private readonly ContextFixture _fixture;
    private readonly IDbContextFactory<StubApplicationContext> _contextFactory;
    private readonly ChallengesController _controller;

    public ChallengeTests(ContextFixture fixture)
    {
        _fixture = fixture;
        _controller = new ChallengesController(_fixture.GetRequiredService<ChallengeService>());
        _contextFactory = _fixture.GetContextFactory();
    }

    [Fact]
    public async Task CreatingAChallenge_GivenAValidChallengeToController_ShouldAddToDatabase()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        Guid challengeId = Guid.NewGuid();
        Guid orgId = Guid.Parse("00000000-0000-0000-0000-000000000001");
        InitializeOrganization(orgId);
        var challenge = CreateValidOrganization(challengeId, orgId);

        await _controller.CreateChallenge(challenge);
        var result = await context.Challenges.FindAsync(challengeId);

        Assert.Equivalent(challenge, result);
    }

    private Challenge CreateValidOrganization(Guid id, Guid orgId)
    {
        return new Challenge
        {
            Id = id,
            Title = "Test Challenge",
            FinalReport = "Final Report",
            ShortDescription = "Short Description",
            Description = "Description",
            ChallengeVisibility = Visibility.VisibleToEmployees,
            OrganizationId = orgId,
            Deadline = DateTime.Now,
        };
    }

    private void InitializeOrganization(Guid id)
    {
        using var context = _contextFactory.CreateDbContext();
        var organization = new Organization { Id = id, Name = "TestOrg", };

        context.Organizations.Add(organization);
        context.SaveChanges();
    }
}
