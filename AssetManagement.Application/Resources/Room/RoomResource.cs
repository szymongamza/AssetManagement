using AssetManagement.Application.Resources.Building;

namespace AssetManagement.Application.Resources.Room;
public class RoomResource
{
    public int Id { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime LastModifiedUtc { get; set; }
    public string Code { get; set; }
    public BuildingResource Building { get; set; }
}
