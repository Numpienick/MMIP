using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace Infrastructure;

public class ApplicationContext : DbContext
{
    public DbSet<Challenge> Challenges { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Branche> Branches { get; set; }
    public DbSet<Phase> Phases { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) { }
}
