using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetManagement.Domain.Contracts;

namespace AssetManagement.Domain.Entities
{
    public class Asset : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string AssetName { get; set; } = null!;
        public Manufacturer? Manufacturer { get; set; }
        public string? ManufacturerSerialNumber { get; set; }
        public DateTime? DateTimeOfBuy { get; set; }
        public DateTime? DateTimeOfNextMaintenance { get; set; }
        public DateTime? DateTimeOfEndOfGuarantee { get; set; }
        public string? AdditionalDescription { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;
        public IEnumerable<Maintenance>? Maintenances { get; set; }

    }
}
