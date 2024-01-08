using MMIP.Shared.Enums;
using MMIP.Shared.Interfaces;

namespace MMIP.Shared.Views;

public class ChallengeCardView : ICarouselItem
{
    public Guid ChallengeId { get; set; }
    public string Title { get; set; } = null!;
    public string ShortDescription { get; set; } = null!;
    public Visibility ChallengeVisibility { get; set; }
    public string BannerImagePath { get; set; } = null!;
    public string? LogoImagePath { get; set; }
    public Guid OrganizationId { get; set; }
    public string OrganizationName { get; set; } = null!;

    public string[] Tags =>
        TagsString?.Split(
            ';',
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
        ) ?? Array.Empty<string>();

    public string? TagsString { get; set; }
}
