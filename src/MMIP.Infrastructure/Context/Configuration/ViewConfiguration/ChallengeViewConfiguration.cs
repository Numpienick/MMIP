using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMIP.Shared.Views;

namespace MMIP.Infrastructure.Context.Configuration.ViewConfiguration;

internal class ChallengeViewConfiguration : IEntityTypeConfiguration<ChallengeView>
{
    public void Configure(EntityTypeBuilder<ChallengeView> builder)
    {
        builder.ToView("challenge_view").HasNoKey();
        builder.Ignore(cv => cv.CreatorName); // TODO: remove when identity is implemented
    }
}
