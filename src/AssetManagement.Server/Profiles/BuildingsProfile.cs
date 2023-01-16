using AssetManagement.Server.Dtos.BuildingDtos;
using AssetManagement.Server.Model;
using AutoMapper;

namespace AssetManagement.Server.Profiles
{
    public class BuildingsProfile : Profile
    {
        public BuildingsProfile()
        {
            CreateMap<Building, BuildingReadDto>();
            CreateMap<BuildingCreateDto, Building>();
        }
    }
}
