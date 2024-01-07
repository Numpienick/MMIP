namespace MMIP.Shared.Entities;

public class OrganizationProfile : IProfile
{
    public Guid Id { get; init; }
    public string Name { get; set; } = "";
    public string BannerImagePath { get; set; } = "";
    public string Description { get; set; } = "";
    public string AvatarPath { get; set; } = "";
    public string Sector { get; set; } = "";
    public string[] Tags { get; set; } = Array.Empty<string>();
}
