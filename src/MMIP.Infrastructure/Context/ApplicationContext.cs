using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MMIP.Environment;
using MMIP.Shared.Entities;
using MMIP.Infrastructure.Context.Configuration.Converters;
using MMIP.Infrastructure.Context.Configuration.EntityConfigurations;
using MMIP.Infrastructure.Context.Configuration.ViewConfiguration;
using MMIP.Shared.Enums;
using MMIP.Shared.Views;

namespace MMIP.Infrastructure.Context;

public class ApplicationContext : ApiAuthorizationDbContext<User>
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

    #region views

    public DbSet<ChallengeCardView> ChallengeCardView { get; set; }
    public DbSet<ChallengeView> ChallengeView { get; set; }
    public DbSet<CommentView> CommentViews { get; set; }

    #endregion

    public ApplicationContext(
        DbContextOptions<ApplicationContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions
    )
        : base(options, operationalStoreOptions) { }

    #region required

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(EnvironmentConstants.DatabaseConnectionString())
            .UseSnakeCaseNamingConvention();
#if DEBUG
        optionsBuilder.EnableSensitiveDataLogging();
#endif
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        # region entities configuration

        modelBuilder.ApplyConfiguration(new ChallengeConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
        modelBuilder.ApplyConfiguration(new ChallengeCardViewConfiguration());
        modelBuilder.ApplyConfiguration(new SectorConfiguration());
        modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
        modelBuilder.ApplyConfiguration(new IndustryConfiguration());
        modelBuilder.ApplyConfiguration(new PhaseConfiguration());
        modelBuilder.ApplyConfiguration(new CommentTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        #endregion

        # region views configuration

        modelBuilder.ApplyConfiguration(new ChallengeCardViewConfiguration());
        modelBuilder.ApplyConfiguration(new ChallengeViewConfiguration());
        modelBuilder.ApplyConfiguration(new CommentViewConfiguration());

        # endregion
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTimeOffset>().HaveConversion<DateTimeOffsetConverter>();
        configurationBuilder.Properties<DateTime>().HaveConversion<DateTimeConverter>();
        configurationBuilder.Properties<Visibility>().HaveConversion<EnumConverter<Visibility>>();
    }

    #endregion
}
