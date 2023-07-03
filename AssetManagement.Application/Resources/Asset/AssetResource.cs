
using AssetManagement.Application.Resources.Manufacturer;
using AssetManagement.Application.Resources.Room;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Resources.Asset;

public class AssetResource
{
    public int Id { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime LastModifiedUtc { get; set; }
    public string Name { get; set; }
    public ManufacturerResource Manufacturer { get; set; }
    public string Model { get; set; }
    public string ManufacturerSerialNumber { get; set; }
    public DateTime? DateTimeOfBuy { get; set; }
    public DateTime? DateTimeOfNextMaintenance { get; set; }
    public DateTime? DateTimeOfEndOfGuarantee { get; set; }
    public string AdditionalDescription { get; set; }
    public bool Hidden { get; set; } = false;
    public Guid QrCode { get; set; }
    public RoomResource Room { get; set; }
}
