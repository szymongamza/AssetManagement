
namespace AssetManagement.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomName { get; set; } = null!;
        public int BuildingId { get; set; }
        public Building Building { get; set; } = null!;
    }
}
