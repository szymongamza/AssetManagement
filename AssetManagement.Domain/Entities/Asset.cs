using AssetManagement.Domain.Common;

namespace AssetManagement.Domain.Entities;

public class Asset : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public int? ManufacturerId { get; set; }
    public Manufacturer? Manufacturer { get; set; }
    public string? Model { get; set; }
    public string? ManufacturerSerialNumber { get; set; }
    public DateTime? DateTimeOfBuy { get; set; }
    public DateTime? DateTimeOfNextMaintenance { get; set; }
    public DateTime? DateTimeOfEndOfGuarantee { get; set; }
    public string? AdditionalDescription { get; set; }
    public Guid QrCode { get; set; } = Guid.NewGuid();
    public int RoomId { get; set; }
    public Room Room { get; set; } = null!;
    public ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();

}