using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Context.Configuration.EntityConfiguration;

internal class PhaseConfiguration : BaseEntityConfiguration<Phase>
{
    public override void Configure(EntityTypeBuilder<Phase> builder)
    {
        base.Configure(builder);
        builder.Property(p => p.Name).HasMaxLength(24).IsRequired();
        builder.Property(p => p.Order).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(254).IsRequired();
        builder
            .HasMany(p => p.VisibleTo)
            .WithMany()
            .UsingEntity(
                "phase_visible_to_user_groups",
                j => j.Property("VisibleToId").HasColumnName("user_group_id")
            );
    }
}
