using AssetManagement.Application.Resources.Asset;
using AssetManagement.Application.Resources.Stocktaking;

namespace AssetManagement.Application.Resources.AssetStocktaking;

public class AssetStocktakingResource
{
    public AssetResource Asset { get; set; }
    public DateTime? ScannedTime { get; set; }
    public bool IsScanned { get; set; }
}
