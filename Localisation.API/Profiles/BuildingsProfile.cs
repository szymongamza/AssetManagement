using AutoMapper;
using Localisation.API.Model;
using Localisation.API.Dtos;

namespace Localisation.API.Profiles
{
    public class BuildingsProfile : Profile
    {
        public BuildingsProfile()
        {
            CreateMap<Building, BuildingReadDto>();
            CreateMap<BuildingCreateDto, Building>();

            CreateMap<Room, RoomReadDto>();
            CreateMap<RoomCreateDto, Room>();

        }
    }
}
