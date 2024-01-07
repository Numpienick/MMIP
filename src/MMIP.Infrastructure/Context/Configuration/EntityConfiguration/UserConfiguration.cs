using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Context.Configuration.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.Property(u => u.FirstName).HasMaxLength(60).IsRequired();
        builder.Property(u => u.LastName).HasMaxLength(60).IsRequired();
        builder.Property(u => u.Email).HasMaxLength(256).IsRequired();
        builder.Property(u => u.Description).HasMaxLength(100000).IsRequired();
        builder.Property(u => u.AvatarPath).HasMaxLength(254);
        builder.Property(u => u.Preposition).HasMaxLength(50);
        builder.Property(u => u.AgreedToPrivacy).IsRequired();
        builder.Property(u => u.AgreedToPrivacyDateTimeStamp);
        builder
            .Property(u => u.FullName)
            .HasComputedColumnSql(
                @"
        CASE
            WHEN preposition IS NOT NULL THEN first_name || ' ' || preposition || ' ' || last_name
            ELSE first_name || ' ' || last_name
        END
    ",
                stored: true
            );
        builder.Ignore(u => u.PhoneNumber);
        builder.Ignore(u => u.PhoneNumberConfirmed);
    }
}
