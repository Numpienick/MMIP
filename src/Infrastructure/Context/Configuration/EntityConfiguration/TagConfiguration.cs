using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Entities;

namespace Infrastructure.Context.Configuration.EntityConfiguration;

internal class TagConfiguration : BaseEntityConfiguration<Tag>
{
    public override void Configure(EntityTypeBuilder<Tag> builder)
    {
        base.Configure(builder);
        builder.ToTable("tags");

        builder.Property(t => t.Value).IsRequired().HasMaxLength(16);

        builder.HasIndex(t => t.Value).IsUnique();
    }
}
