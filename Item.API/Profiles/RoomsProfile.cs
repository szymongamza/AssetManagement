using AutoMapper;
using Item.API.Dtos;
using Item.API.Model;

namespace Item.API.Profiles
{
    public class RoomsProfile:Profile
    {
        public RoomsProfile()
        {
            CreateMap<Room, RoomReadDto>();
            CreateMap<RoomPublishedDto, Room>()
                .ForMember(dest => dest.ExternalID, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
