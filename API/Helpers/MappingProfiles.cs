using AutoMapper;
using Core.Entities;
using skinet.API.DTOs;

namespace skinet.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDTO>()
            .ForMember(x => x.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
            .ForMember(x => x.ProductType, o => o.MapFrom(s => s.ProductType.Name))
            .ForMember(x => x.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}