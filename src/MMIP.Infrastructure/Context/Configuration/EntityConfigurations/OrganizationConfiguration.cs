using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Context.Configuration.EntityConfigurations;

internal class OrganizationConfiguration : BaseEntityConfiguration<Organization>
{
    private const int NameLength = 128;

    public override void Configure(EntityTypeBuilder<Organization> builder)
    {
        base.Configure(builder);
        builder.Property(o => o.Name).IsRequired().HasMaxLength(NameLength);
        builder.Property(o => o.EnrollmentCode).HasMaxLength(8).IsRequired();
        builder
            .HasOne(o => o.Sector)
            .WithMany()
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.OwnsOne(
            o => o.Profile,
            profile =>
            {
                profile.Property(p => p.Description).HasMaxLength(10000).IsRequired();
                profile.Property(p => p.AvatarPath).HasMaxLength(254);
                profile.Property(p => p.BannerImagePath).HasMaxLength(254);
            }
        );
    }
}