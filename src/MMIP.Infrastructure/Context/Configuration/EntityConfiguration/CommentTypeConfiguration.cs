using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Context.Configuration.EntityConfiguration;

internal class CommentTypeConfiguration : BaseEntityConfiguration<CommentType>
{
    public override void Configure(EntityTypeBuilder<CommentType> builder)
    {
        base.Configure(builder);
        builder.ToTable("comment_types");
        builder.HasIndex(ct => ct.Name).IsUnique();
        builder.Property(ct => ct.Name).HasMaxLength(64).IsRequired();
        builder.Property(ct => ct.IconPath).HasMaxLength(254).IsRequired();
        builder.Property(ct => ct.Description).HasMaxLength(254).IsRequired();
    }
}
