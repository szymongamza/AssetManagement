
using AssetManagement.Application.Resources.Manufacturer;
using AssetManagement.Application.Resources.Room;
using AssetManagement.Application.Resources.User;
using AssetManagement.Domain.Entities;
using AssetManagement.Domain.Enums;

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
    public Guid QrCode { get; set; }
    public string StockNumber { get; set; }
    public AssetStatus AssetStatus { get; set; }
    public RoomResource Room { get; set; }
    public UserResource User { get; set; }
}
