using AssetManagement.Domain.Common;

namespace AssetManagement.Domain.Entities;

public class Stocktaking : BaseAuditableEntity
{
    public DateTime? ClosedUtc { get; set; }
    public bool IsClosed { get; set; } = false;
    public int RoomId { get; set; }
    public Room Room { get; set; }
    public ICollection<Asset> AssetsToStocktake { get; set; } = new List<Asset>();
    public ICollection<Asset> StockTakedAssets { get; set; } = new List<Asset>();
    public ICollection<AssetStocktaking> AssetStocktakings { get; set; } = new List<AssetStocktaking>();

}
