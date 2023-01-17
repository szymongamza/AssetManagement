using AssetManagement.API.Dtos.BuildingDtos;
using AssetManagement.API.Dtos.MaintenanceDtos;
using AssetManagement.API.Dtos.ProductDtos;
using AssetManagement.API.Dtos.RoomDtos;
using AssetManagement.Core.Entities;
using AutoMapper;
namespace AssetManagement.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Building, BuildingReadDto>();
            CreateMap<BuildingCreateDto, Building>();
            CreateMap<Room, RoomReadDto>();
            CreateMap<RoomCreateDto, Room>();
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Maintenance, MaintenanceReadDto>();
            CreateMap<MaintenanceCreateDto, Maintenance>();
        }
    }
}
