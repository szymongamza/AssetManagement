using AssetManagement.Server.Dtos.ProductDtos;
using AssetManagement.Server.Model;
using AutoMapper;

namespace AssetManagement.Server.Profiles
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
