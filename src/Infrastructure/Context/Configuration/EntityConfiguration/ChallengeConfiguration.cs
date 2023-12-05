using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Entities;

namespace Infrastructure.Context.Configuration.EntityConfiguration;

internal class ChallengeConfiguration : BaseEntityConfiguration<Challenge>
{
    public override void Configure(EntityTypeBuilder<Challenge> b)
    {
        base.Configure(b);
        b.HasOne(c => c.Organization)
            .WithMany(o => o.Challenges)
            .HasForeignKey(c => c.OrganizationId)
            .IsRequired()
            .OnDelete(DeleteBehavior.SetNull);

        b.Property(c => c.CurrentPhaseId).IsRequired();

        b.HasMany(c => c.Phases)
            .WithMany()
            .UsingEntity("challenge_phases", j => j.Property("PhasesId").HasColumnName("phase_id"));

        b.Property(c => c.Title).IsRequired().HasMaxLength(128);

        b.Property(c => c.Description).IsRequired().HasMaxLength(DESCRIPTION_MAX_LENGTH);

        b.Property(c => c.ShortDescription).HasMaxLength(SHORT_DESCRIPTION_MAX_LENGTH);

        b.Property(c => c.BannerImagePath).HasMaxLength(254);

        b.Property(c => c.Deadline).IsRequired();

        b.Property(c => c.StartDate).HasDefaultValueSql("NOW()");

        b.Property(c => c.FinalReport).HasMaxLength(DESCRIPTION_MAX_LENGTH);

        b.HasMany("_tags")
            .WithMany("challenges")
            .UsingEntity(
                "challenge_tags",
                j =>
                {
                    j.Property("_tagsId").HasColumnName("tag_id");
                    j.Property("challengesId").HasColumnName("challenge_id");
                }
            );

        b.Property(c => c.ChallengeVisibility).IsRequired();
    }
}
