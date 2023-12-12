using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMIP.Shared.Views;

namespace MMIP.Infrastructure.Context.Configuration.ViewConfiguration;

internal class ChallengeCardViewConfiguration
    : IEntityTypeConfiguration<ChallengeCardView>
{
    public void Configure(EntityTypeBuilder<ChallengeCardView> builder)
    {
        builder.ToView("challenge_card_view").HasNoKey();

        builder.Ignore(c => c.Tags);
        builder.Property("_tags").HasColumnName("tags");
    }
}
