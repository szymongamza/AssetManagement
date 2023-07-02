
using AssetManagement.Application.Resources.Room;
using AssetManagement.Application.Resources;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AutoMapper;

namespace AssetManagement.Application.Helpers;
public class RoomMappingProfile : Profile
{
    public RoomMappingProfile()
    {
        CreateMap<Room, RoomResource>();
        CreateMap<QueryResult<Room>, QueryResultResource<RoomResource>>();
        CreateMap<RoomQueryResource, RoomQuery>();
        CreateMap<SaveRoomResource, Room>()
            .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(x => x.Building, opt => opt.Ignore())
            .ForMember(x => x.LastModifiedUtc, opt => opt.Ignore())
            .ForMember(x => x.CreatedUtc, opt => opt.Ignore());
    }
}
