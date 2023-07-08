
using AssetManagement.Domain.Enums;

namespace AssetManagement.Application.Resources.Asset;

public class SaveAssetResource
{
    public string Name { get; set; }
    public int? ManufacturerId { get; set; }
    public string Model { get; set; }
    public string ManufacturerSerialNumber { get; set; }
    public DateTime? DateTimeOfBuy { get; set; }
    public DateTime? DateTimeOfNextMaintenance { get; set; }
    public DateTime? DateTimeOfEndOfGuarantee { get; set; }
    public string AdditionalDescription { get; set; }
    public string StockNumber { get; set; }
    public AssetStatus AssetStatus { get; set; }
    public int RoomId { get; set; }
    public int UserId { get; set; }
}
