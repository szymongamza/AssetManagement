using AutoMapper;
using Localisation.API.Dtos;
using Localisation.API.Model;

namespace Localisation.API.Profiles
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
