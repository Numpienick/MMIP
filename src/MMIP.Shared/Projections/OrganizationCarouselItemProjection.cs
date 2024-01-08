using MMIP.Shared.Interfaces;

namespace MMIP.Shared.Projections;

public class OrganizationCarouselItemProjection : ICarouselItem
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
}
