
using AssetManagement.Domain.Common;

namespace AssetManagement.Domain.Entities;

public class AssetStocktakingComplete : BaseEntity
{
    public int AssetId { get; set; }
    public int StocktakingId { get; set; }
    public Asset Asset { get; set; }
    public Stocktaking Stocktaking { get; set; }
}
