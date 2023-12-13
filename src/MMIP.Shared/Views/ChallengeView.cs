namespace MMIP.Shared.Views;

public class ChallengeView
{
    public Guid ChallengeId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string BannerImagePath { get; set; } = null!;
    public string? FinalReport { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset Deadline { get; set; }
    public string PhaseName { get; set; } = null!;
    public int Progress { get; set; }
    public string CreatorName { get; set; } = "";
    public string OrganizationProfilePicturePath { get; set; } = "";
    public string OrganizationName { get; set; } = null!;
}
