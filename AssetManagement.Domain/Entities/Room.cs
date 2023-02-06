
using AssetManagement.Domain.Contracts;

namespace AssetManagement.Domain.Entities
{
    public class Room : IEntity<int>
    {
        public int Id { get; set; }
        public string RoomName { get; set; } = null!;
        public int BuildingId { get; set; }
        public Building Building { get; set; } = null!;
    }
}
