using AutoMapper;
using Localisation.API.Dtos;
using Localisation.API.Model;

namespace Localisation.API.Profiles
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
