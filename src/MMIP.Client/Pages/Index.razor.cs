using Microsoft.AspNetCore.Components;
using MMIP.Client.Controllers;
using MMIP.Shared.Views;
using MudBlazor;

namespace MMIP.Client.Pages;

public partial class Index
{
    [Inject]
    private RequestController Client { get; set; } = default!;

    private List<ChallengeCardView> _challenges = new();
    private MudCarousel<ChallengeCardView> _carousel = null!;

    protected override async Task OnInitializedAsync()
    {
        _challenges = await Client.GetRange<ChallengeCardView>("challenges/carousel");
        _carousel.MoveTo(0);
    }
}
