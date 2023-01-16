using AutoMapper;
using AssetManagementAPI.Model;
using AssetManagementAPI.Dtos;

namespace AssetManagementAPI.Profiles
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
