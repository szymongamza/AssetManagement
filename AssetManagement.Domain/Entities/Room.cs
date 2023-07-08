using AssetManagement.Domain.Common;

namespace AssetManagement.Domain.Entities;

public class Room : BaseAuditableEntity
{
    public string Code { get; set; }
    public int BuildingId { get; set; }
    public Building Building { get; set; }
    public ICollection<Stocktaking> Stocktakings { get; set; } = new List<Stocktaking>();
    public ICollection<Asset> Assets { get; set; } = new List<Asset>();
}