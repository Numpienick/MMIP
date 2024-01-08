using AutoMapper;
using MMIP.Shared.Entities;
using MMIP.Shared.Projections;

namespace MMIP.Infrastructure.Context.Configuration.Projections;

public class OrganizationCarouselItemProjectionProfile : Profile
{
    public OrganizationCarouselItemProjectionProfile()
    {
        CreateMap<Organization, OrganizationCarouselItemProjection>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(
                dest => dest.ImagePath,
                opt => opt.MapFrom(src => src.Profile.BannerImagePath)
            );
    }
}
