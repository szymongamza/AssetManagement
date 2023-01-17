using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Core.Entities
{
    public class Room : BaseEntity
    {
        public string? Name { get; set; }
        public int Floor { get; set; }
        public int BuildingId { get; set; }
        public Building? Building { get; set; }
        public IEnumerable<Product>? Products { get; set; }

    }
}
