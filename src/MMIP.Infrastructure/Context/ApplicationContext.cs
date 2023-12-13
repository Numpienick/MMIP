using Microsoft.EntityFrameworkCore;
using MMIP.Shared.Entities;
using MMIP.Infrastructure.Context.Configuration.Converters;
using MMIP.Infrastructure.Context.Configuration.EntityConfiguration;
using MMIP.Infrastructure.Context.Configuration.ViewConfiguration;
using MMIP.Shared.Enums;
using MMIP.Shared.Views;

namespace MMIP.Infrastructure.Context;

public class ApplicationContext : DbContext
{
    # region entities

    public DbSet<Challenge> Challenges { get; set; }
    public DbSet<CommentType> CommentTypes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Sector> Sectors { get; set; }
    public DbSet<Industry> Industries { get; set; }
    public DbSet<Phase> Phases { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<Tag> Tags { get; set; }

    #endregion

    #region views

    public DbSet<ChallengeCardView> ChallengeCardComponents { get; set; }

    #endregion

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) { }

    #region required

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ChallengeConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
        modelBuilder.ApplyConfiguration(new ChallengeCardViewConfiguration());
        modelBuilder.ApplyConfiguration(new SectorConfiguration());
        modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
        modelBuilder.ApplyConfiguration(new IndustryConfiguration());
        modelBuilder.ApplyConfiguration(new PhaseConfiguration());
        modelBuilder.ApplyConfiguration(new CommentTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTimeOffset>().HaveConversion<DateTimeOffsetConverter>();
        configurationBuilder.Properties<DateTime>().HaveConversion<DateTimeConverter>();
        configurationBuilder.Properties<Visibility>().HaveConversion<EnumConverter<Visibility>>();
    }

    #endregion
}
