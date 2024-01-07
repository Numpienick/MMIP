using AutoMapper;
using MMIP.Shared.Entities;

namespace MMIP.Infrastructure.Context.Configuration.EntityConfigurations;

public class OrganizationProfileProfile : Profile
{
    public OrganizationProfileProfile()
    {
        CreateMap<Organization, OrganizationProfile>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(t => t.Value)))
            .ForMember(dest => dest.Sector, opt => opt.MapFrom(src => src.Sector.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Profile.Description))
            .ForMember(
                dest => dest.BannerImagePath,
                opt => opt.MapFrom(src => src.Profile.BannerImagePath)
            )
            .ForMember(dest => dest.AvatarPath, opt => opt.MapFrom(src => src.Profile.AvatarPath));
    }
}
