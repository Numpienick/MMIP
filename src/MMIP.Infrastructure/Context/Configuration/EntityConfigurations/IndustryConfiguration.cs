using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Context.Configuration.EntityConfigurations;

internal class IndustryConfiguration : BaseEntityConfiguration<Industry>
{
    public override void Configure(EntityTypeBuilder<Industry> builder)
    {
        base.Configure(builder);
        builder.ToTable("industries");
        builder.Property(i => i.Name).HasMaxLength(254).IsRequired();

        builder.HasOne(i => i.Sector).WithMany().IsRequired();
    }
}
