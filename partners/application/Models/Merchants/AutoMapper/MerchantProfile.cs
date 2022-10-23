using AutoMapper;
using Easyfood.Partners.Domain.Entities;

namespace Easyfood.Partners.Application.Models.Merchants.AutoMapper
{
    public class MerchantProfile : Profile
    {
        public MerchantProfile()
        {
            CreateMap<Merchant, MerchantDto>()
                .ForMember(dest => dest.MerchantLogo, opt => opt.MapFrom(src => src.CompanyLogo))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyName))
                .ForMember(dest => dest.CompanyType, opt => opt.MapFrom(src => src.CompanyCategory.ToString()))
                .ForMember(dest => dest.Delivery, opt => opt.Ignore());
        }
    }
}