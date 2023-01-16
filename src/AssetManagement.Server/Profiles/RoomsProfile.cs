using AssetManagement.Server.Dtos.RoomDtos;
using AssetManagement.Server.Model;
using AutoMapper;

namespace AssetManagement.Server.Profiles
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
