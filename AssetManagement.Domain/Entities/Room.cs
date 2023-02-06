
using AssetManagement.Domain.Contracts;

namespace AssetManagement.Domain.Entities
{
    public class Room : Entity<int>
    {
        public string RoomName { get; set; } = null!;
        public int BuildingId { get; set; }
        public Building Building { get; set; } = null!;
    }
}
