using Microsoft.EntityFrameworkCore;
using MMIP.Infrastructure.Context.Configuration.Converters;
using MMIP.Infrastructure.Context.Configuration.EntityConfigurations;
using MMIP.Shared.Entities;
using MMIP.Shared.Enums;

namespace MMIP.Test.Infrastructure.Stubs;

public class StubApplicationContext : DbContext
{
    # region entities

    public DbSet<Challenge> Challenges { get; set; }
    public DbSet<CommentType> CommentTypes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Sector> Sectors { get; set; }
    public DbSet<Industry> Industries { get; set; }
    public DbSet<Phase> Phases { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<Tag> Tags { get; set; }

    #endregion

    public StubApplicationContext(DbContextOptions<StubApplicationContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ChallengeConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTimeOffset>().HaveConversion<DateTimeOffsetConverter>();
        configurationBuilder.Properties<DateTime>().HaveConversion<DateTimeConverter>();
        configurationBuilder.Properties<Visibility>().HaveConversion<EnumConverter<Visibility>>();
    }
}
