
using AssetManagement.Application.Resources.Asset;
using AssetManagement.Application.Resources.Room;

namespace AssetManagement.Application.Resources.Stocktaking;

public class StocktakingResource
{
    public int Id { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime LastModifiedUtc { get; set; }
    public DateTime? ClosedUtc { get; set; }
    public bool IsClosed { get; set; } = false;
    public RoomResource Room { get; set; }
    public ICollection<AssetResource> StocktakedAssets { get; set; } = new List<AssetResource>();
    public ICollection<AssetResource> AssetsToStocktake { get; set; } = new List<AssetResource>();
}
