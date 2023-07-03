
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
    public bool Hidden { get; set; } = false;
    public int RoomId { get; set; }
}
