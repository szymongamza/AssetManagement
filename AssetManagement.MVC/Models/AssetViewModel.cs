using AssetManagement.Domain.Entities;

namespace AssetManagement.MVC.Models;

public class AssetViewModel
{
    public string Name { get; set; } = null!;
    public Manufacturer? Manufacturer { get; set; }
    public string? Model { get; set; }
    public string? ManufacturerSerialNumber { get; set; }
    public DateTime? DateTimeOfBuy { get; set; }
    public DateTime? DateTimeOfNextMaintenance { get; set; }
    public DateTime? DateTimeOfEndOfGuarantee { get; set; }
    public string? AdditionalDescription { get; set; }
    public Guid QrCode { get; set; } = Guid.NewGuid();
    public Faculty Faculty { get; set; } = null!;
    public Department Department { get; set; } = null!;
    public Building Building { get; set; } = null!;
    public Room Room { get; set; } = null!;
    public ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();
}
