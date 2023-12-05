namespace Shared.Views;

public class ChallengeCardComponent
{
    public Guid ChallengeId { get; set; }
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string BannerImagePath { get; set; }
    public string OrganizationName { get; set; }
    public string[] Tags => _tags.Split(';', StringSplitOptions.TrimEntries);
    private string _tags { get; set; }
}
