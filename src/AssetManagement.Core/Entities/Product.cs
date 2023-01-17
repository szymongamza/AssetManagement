using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Core.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public string? Manufacturer { get; set; }
        public string? ManufacturerSerialNumber { get; set; }
        public DateTime DateTimeOfBuy { get; set; }
        public DateTime DateTimeOfNextMaintenance { get; set; }
        public DateTime DateTimeOfEndOfGuarantee { get; set; }
        public string? AdditionalDescription { get; set; }
        public int RoomId { get; set; }
        public Room? Room { get; set; }
        public Guid ItemGuid { get; set; } = Guid.NewGuid();
        public bool EmailNotification { get; set; }
        public IEnumerable<Maintenance>? Maintenances {get; set;}

    }
}
