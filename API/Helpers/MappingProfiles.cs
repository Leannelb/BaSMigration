using AutoMapper;
using API.Dtos;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
            .ForMember(d => d.ProductBrand, options => options.MapFrom(source => source.ProductBrand.Name))
            .ForMember(d => d.ProductType, options => options.MapFrom(source => source.ProductType.Name));

        }
    }
}