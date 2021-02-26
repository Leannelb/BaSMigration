  
using API.DataTransferObjects;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductsUrlResolver>());
            CreateMap<Address, AddressDto>().ReverseMap();
            // in our update address DTO we take an AddressDto in as the parameter and we want to map this into an address
            // we map our address to our address Dto so auto mapper will now map these together as they have the exact same name. 
        }
    }
}