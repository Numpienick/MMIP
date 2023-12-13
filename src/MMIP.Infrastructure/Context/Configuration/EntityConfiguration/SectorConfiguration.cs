using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Context.Configuration.EntityConfiguration;

internal class SectorConfiguration : BaseEntityConfiguration<Sector>
{
    public override void Configure(EntityTypeBuilder<Sector> builder)
    {
        base.Configure(builder);
        builder.Property(s => s.Name).IsRequired().HasMaxLength(254);
    }
}
