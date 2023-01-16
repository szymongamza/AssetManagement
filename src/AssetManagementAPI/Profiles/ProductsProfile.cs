using AutoMapper;
using AssetManagementAPI.Dtos;
using AssetManagementAPI.Model;

namespace AssetManagementAPI.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductCreateDto, Product>();
        }
    }
}
