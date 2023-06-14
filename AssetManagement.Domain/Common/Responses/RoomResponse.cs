using AssetManagement.Domain.Entities;

namespace AssetManagement.Domain.Common.Responses; 
public class RoomResponse : BaseResponse<Room>
{
    public RoomResponse(Room resource) : base(resource)
    {
    }

    public RoomResponse(string message) : base(message)
    {
    }
}
