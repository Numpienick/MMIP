using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MMIP.Shared.Entities;

namespace MMIP.Shared.Contexts
{
    public class ChallengeContext : IdentityDbContext<IdentityUser>
    {
        public ChallengeContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Challenge> Products { get; set; }
    }
}
