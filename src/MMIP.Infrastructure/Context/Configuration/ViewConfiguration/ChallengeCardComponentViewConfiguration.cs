using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMIP.Shared.Views;

namespace MMIP.Infrastructure.Context.Configuration.ViewConfiguration;

internal class ChallengeCardComponentViewConfiguration
    : IEntityTypeConfiguration<ChallengeCardComponentView>
{
    public void Configure(EntityTypeBuilder<ChallengeCardComponentView> builder)
    {
        builder.ToView("challenge_card_component_view").HasNoKey();

        builder.Ignore(c => c.Tags);
        builder.Property("_tags").HasColumnName("tags");
    }
}
