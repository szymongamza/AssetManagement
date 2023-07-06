

using AssetManagement.Domain.Common;

namespace AssetManagement.Domain.Entities;

public class AssetStocktaking : BaseEntity
{
    public int AssetId { get; set; }
    public int StocktakingId { get; set; }
    public Asset Asset { get; set; }
    public Stocktaking Stocktaking { get; set; }
    public DateTime? ScannedTime { get; set; }
    public bool IsScanned { get; set; } = false;
}
