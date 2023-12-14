using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Context.Configuration.EntityConfiguration;

internal class CommentConfiguration : BaseEntityConfiguration<Comment>
{
    public override void Configure(EntityTypeBuilder<Comment> builder)
    {
        base.Configure(builder);
        builder.Property(c => c.Text).HasMaxLength(1000).IsRequired();
        builder.HasOne<CommentType>().WithMany().HasForeignKey(c => c.CommentTypeId).IsRequired();
        builder
            .HasOne<Challenge>()
            .WithMany()
            .HasForeignKey(c => c.ChallengeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        // TODO: add CreatorId reference when Identity is implemented
    }
}
