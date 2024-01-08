using Microsoft.AspNetCore.Components;
using MMIP.Shared.Entities;
using MMIP.Shared.Views;

namespace MMIP.Client.Pages;

public partial class Profile
{
    [Inject]
    NavigationManager NavigationManager { get; set; } = null!;

    [Parameter]
    public Guid EntityId { get; set; }

    [Parameter]
    public string? ProfileType { get; set; }

    private const int BatchSize = 6;

    private readonly List<ChallengeCardView> _challenges = new();

    private IProfile? ProfileData { get; set; }
    private string _challengesUri = "";
    private bool _gotAllChallenges;

    protected override async Task OnInitializedAsync()
    {
        if (string.IsNullOrEmpty(ProfileType))
        {
            NavigationManager.NavigateTo($"/Error", forceLoad: true);
            return;
        }

        ProfileType = ProfileType.ToLower();
        switch (ProfileType)
        {
            case "organization":
                ProfileData = await _getProfile<OrganizationProfile>(
                    $"organizations/profile?id={EntityId}"
                );
                _challengesUri = $"organizations/challenges/overview?id={ProfileData.Id}";
                break;
            case "user":
                break;
            default:
                NavigationManager.NavigateTo($"/Error/{ProfileType}", forceLoad: true);
                return;
        }

        await _loadChallenges();
    }

    private async Task _loadChallenges()
    {
        var uri = $"{_challengesUri}&take={BatchSize}&skip={_challenges.Count}";
        var cards = await RequestController.GetRange<ChallengeCardView>(uri);

        if (cards.Count < BatchSize)
            _gotAllChallenges = true;

        _challenges.AddRange(cards);
        StateHasChanged();
    }

    private async Task<TProfile> _getProfile<TProfile>(string uri)
        where TProfile : IProfile, new()
    {
        var profile = await RequestController.Get<TProfile>(uri);
        if (profile is not null)
            return profile;

        NavigationManager.NavigateTo($"/Error/{typeof(TProfile).Name}", forceLoad: true);
        return new TProfile();
    }
}
