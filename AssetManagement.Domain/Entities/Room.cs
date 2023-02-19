namespace AssetManagement.Domain.Entities
{
    public class Room : BaseEntity
    {
        public string RoomName { get; set; } = null!;
        public int BuildingId { get; set; }
        public Building Building { get; set; } = null!;
    }
}
