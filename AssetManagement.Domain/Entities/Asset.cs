using AssetManagement.Domain.Common;
using AssetManagement.Domain.Enums;

namespace AssetManagement.Domain.Entities;

public class Asset : BaseAuditableEntity
{
    public string Name { get; set; }
    public int? ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public string Model { get; set; }
    public string ManufacturerSerialNumber { get; set; }
    public DateTime? DateTimeOfBuy { get; set; }
    public DateTime? DateTimeOfNextMaintenance { get; set; }
    public DateTime? DateTimeOfEndOfGuarantee { get; set; }
    public string AdditionalDescription { get; set; }
    public AssetStatus Status { get; set; } = AssetStatus.OnSite;
    public Guid QrCode { get; set; } = Guid.NewGuid();
    public int RoomId { get; set; }
    public Room Room { get; set; }
    public ICollection<Stocktaking> Stocktakings { get; set; } = new List<Stocktaking>();
    public ICollection<AssetStocktaking> AssetStocktakings { get; set; } = new List<AssetStocktaking>();
}