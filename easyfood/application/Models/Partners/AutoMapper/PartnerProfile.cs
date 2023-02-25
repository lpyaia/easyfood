using AutoMapper;
using Easyfood.Domain.Entities;

namespace Easyfood.Application.Models.Partners.AutoMapper
{
    public class PartnerProfile : Profile
    {
        public PartnerProfile()
        {
            CreateMap<Partner, PartnerDto>()
                .ForMember(dest => dest.PartnerLogo, opt => opt.MapFrom(src => src.CompanyLogo))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyName))
                .ForMember(dest => dest.CompanyType, opt => opt.MapFrom(src => src.CompanyCategory.ToString()))
                .ForMember(dest => dest.Delivery, opt => opt.Ignore());
        }
    }
}