using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMIP.Infrastructure.Helpers;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Context.Configuration.EntityConfiguration;

internal class OrganizationConfiguration : BaseEntityConfiguration<Organization>
{
    public override void Configure(EntityTypeBuilder<Organization> builder)
    {
        base.Configure(builder);
        builder.Property(o => o.Name).IsRequired().HasMaxLength(128);
        builder
            .Property(o => o.EnrollmentCode)
            .HasDefaultValue(EnrollmentCodeGenerator.GenerateEnrollmentCode())
            .HasMaxLength(8);
        builder.HasOne<Sector>().WithMany().HasForeignKey(o => o.SectorId).IsRequired();
    }
}
