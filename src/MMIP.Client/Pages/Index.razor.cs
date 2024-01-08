using Microsoft.AspNetCore.Components;
using MMIP.Client.Controllers;
using MMIP.Shared.Interfaces;
using MMIP.Shared.Projections;
using MMIP.Shared.Views;
using MudBlazor;

namespace MMIP.Client.Pages;

public partial class Index
{
    [Inject]
    private RequestController Client { get; set; } = default!;

    private const int CarouselItemsToTake = 5;

    private readonly List<ICarouselItem> _items = new();
    private MudCarousel<ICarouselItem> _carousel = null!;

    protected override async Task OnInitializedAsync()
    {
        var challenges = await Client.GetRange<ChallengeCardView>(
            $"challenges/carousel?take={CarouselItemsToTake}"
        );
        var organizations = await Client.GetRange<OrganizationCarouselItemProjection>(
            $"organizations/carousel?take={CarouselItemsToTake}"
        );

        int index = 0;
        while (challenges.Count > index || organizations.Count > index)
        {
            if (challenges.Count > index)
            {
                _items.Add(challenges[index]);
            }

            if (organizations.Count > index)
            {
                _items.Add(organizations[index]);
            }

            index++;
        }

        _carousel.MoveTo(0);
    }
}
