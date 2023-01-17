using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Core.Entities
{
    public class Building : BaseEntity
    {
        public string? Name { get; set; }
        public string? BuildingCode { get; set; }
        public int MinFloor { get; set; }
        public int MaxFloor { get; set; }
        public IEnumerable<Room>? Rooms { get; set; }

    }
}
