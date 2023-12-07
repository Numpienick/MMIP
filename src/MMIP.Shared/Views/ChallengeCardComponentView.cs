namespace MMIP.Shared.Views;

public class ChallengeCardComponentView
{
    public Guid ChallengeId { get; set; }
    public string Title { get; set; } = null!;
    public string ShortDescription { get; set; } = null!;
    public string BannerImagePath { get; set; } = null!;
    public string OrganizationName { get; set; } = null!;

    public string[] Tags =>
        _tags?.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
        ?? Array.Empty<string>();

    private string? _tags { get; }
}
