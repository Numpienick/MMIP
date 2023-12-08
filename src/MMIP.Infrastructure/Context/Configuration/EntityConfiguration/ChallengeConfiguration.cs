using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Context.Configuration.EntityConfiguration;

internal class ChallengeConfiguration : BaseEntityConfiguration<Challenge>
{
    public override void Configure(EntityTypeBuilder<Challenge> builder)
    {
        base.Configure(builder);
        builder
            .HasOne<Organization>()
            .WithMany(o => o.Challenges)
            .HasForeignKey(c => c.OrganizationId)
            .IsRequired();

        builder.Property(c => c.CurrentPhaseId).IsRequired();

        builder
            .HasMany(c => c.Phases)
            .WithMany()
            .UsingEntity("challenge_phases", j => j.Property("PhasesId").HasColumnName("phase_id"));

        builder.Property(c => c.Title).IsRequired().HasMaxLength(128);

        builder.Property(c => c.Description).IsRequired().HasMaxLength(DESCRIPTION_MAX_LENGTH);

        builder.Property(c => c.ShortDescription).HasMaxLength(SHORT_DESCRIPTION_MAX_LENGTH);

        builder.Property(c => c.BannerImagePath).HasMaxLength(254);

        builder.Property(c => c.Deadline).IsRequired();

        builder.Property(c => c.StartDate).HasDefaultValueSql("NOW()");

        builder.Property(c => c.FinalReport).HasMaxLength(DESCRIPTION_MAX_LENGTH);

        builder
            .HasMany(c => c.Tags)
            .WithMany()
            .UsingEntity("challenge_tags", j => j.Property("TagsId").HasColumnName("tag_id"));

        builder.Property(c => c.ChallengeVisibility).IsRequired();
    }
}
