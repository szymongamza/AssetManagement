
using System.Xml.Linq;
using AssetManagement.Application.Resources.AssetStocktaking;
using AssetManagement.Application.Resources.Room;

namespace AssetManagement.Application.Resources.Stocktaking;

public class StocktakingResource
{
    public int Id { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime LastModifiedUtc { get; set; }
    public DateTime? ClosedUtc { get; set; }
    public bool IsClosed { get; set; }
    public RoomResource Room { get; set; }
    public ICollection<AssetStocktakingResource> Assets { get; set; } = new List<AssetStocktakingResource>();
    public int ScannedAssets { get; set; }
    public int TotalAssets { get; set; }
}
