using Infrastructure.Context.Configuration.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using Infrastructure.Context.Configuration.Converters;
using Infrastructure.Context.Configuration.ViewConfiguration;
using Shared.Enums;
using Shared.Views;

namespace Infrastructure.Context;

public class ApplicationContext : DbContext
{
    # region entities

    public DbSet<Challenge> Challenges { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Branche> Branches { get; set; }
    public DbSet<Phase> Phases { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<Tag> Tags { get; set; }

    #endregion

    #region views

    public DbSet<ChallengeCardComponent> ChallengeCardComponents { get; set; }

    #endregion

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) { }

    #region required

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ChallengeConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
        modelBuilder.ApplyConfiguration(new ChallengeCardComponentConfiguration());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTimeOffset>().HaveConversion<DateTimeOffsetConverter>();
        configurationBuilder.Properties<DateTime>().HaveConversion<DateTimeConverter>();
        configurationBuilder.Properties<Visibility>().HaveConversion<EnumConverter<Visibility>>();
        configurationBuilder.Properties<CommentType>().HaveConversion<EnumConverter<CommentType>>();
    }

    #endregion
}
