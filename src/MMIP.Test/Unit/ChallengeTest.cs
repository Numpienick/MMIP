using Microsoft.EntityFrameworkCore;

namespace MMIP.Test.Unit;

[Collection(nameof(ContextFixtureCollection))]
public class ChallengeTest
{
    private ContextFixture _fixture { get; }
    private readonly Guid _orgId;
    private readonly IDbContextFactory<ApplicationContext> _contextFactory;

    public ChallengeTest(ContextFixture fixture)
    {
        _fixture = fixture;
        _contextFactory = _fixture.GetContextFactory();
        _orgId = Guid.NewGuid();
        InitializeOrganization();
    }

    [Fact]
    public async Task TooBigDescription_DoesntAddToDatabase()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var id = Guid.NewGuid();
        var challenge = new Challenge
        {
            Id = id,
            Title = "Test Too Big Description",
            FinalReport = "Final Report",
            ShortDescription = "Short Description",
            Description = new string('a', 100001),
            ChallengeVisibility = Visibility.VisibleToAll,
            OrganizationId = _orgId,
            Deadline = DateTime.Now
        };

        // TODO: Catch the error thrown by the database and assert that it is the correct error
        await context.Challenges.AddAsync(challenge);
        await context.SaveChangesAsync();
        var result = await context.Challenges.FindAsync(id);

        Assert.Null(result);
    }

    [Fact]
    public async Task Description_AddToDatabase()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var id = Guid.NewGuid();
        var challenge = new Challenge
        {
            Id = id,
            Title = "Test",
            FinalReport = "Final Report",
            ShortDescription = "Short Description",
            Description = new string('a', 99999),
            ChallengeVisibility = Visibility.VisibleToAll,
            OrganizationId = _orgId,
            Deadline = DateTime.Now
        };

        await context.Challenges.AddAsync(challenge);
        await context.SaveChangesAsync();
        var result = await context.Challenges.FindAsync(id);

        Assert.Equivalent(challenge, result);
    }

    private void InitializeOrganization()
    {
        using var context = _contextFactory.CreateDbContext();
        var organization = new Organization { Id = _orgId, Name = "TestOrg", };

        context.Organizations.Add(organization);
        context.SaveChanges();
    }
}
