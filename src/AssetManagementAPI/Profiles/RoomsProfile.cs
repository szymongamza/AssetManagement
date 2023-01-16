using AutoMapper;
using AssetManagementAPI.Dtos;
using AssetManagementAPI.Model;

namespace AssetManagementAPI.Profiles
{
    public class RoomsProfile : Profile
    {
        public RoomsProfile()
        {
            CreateMap<Room, RoomReadDto>();
            CreateMap<RoomCreateDto, Room>();
        }
    }
}
