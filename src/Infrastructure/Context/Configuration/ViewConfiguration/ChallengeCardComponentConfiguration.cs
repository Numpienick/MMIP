using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Views;

namespace Infrastructure.Context.Configuration.ViewConfiguration;

internal class ChallengeCardComponentConfiguration
    : IEntityTypeConfiguration<ChallengeCardComponent>
{
    public void Configure(EntityTypeBuilder<ChallengeCardComponent> builder)
    {
        builder.ToView("challenge_card_component_view").HasNoKey();

        builder.Ignore(c => c.Tags);
        builder.Property("_tags").HasColumnName("tags");
    }
}
