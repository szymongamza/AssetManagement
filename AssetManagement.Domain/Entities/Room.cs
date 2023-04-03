using AssetManagement.Domain.Common;

namespace AssetManagement.Domain.Entities;

public class Room : BaseAuditableEntity
{
    public string? Code { get; set; }
    public string? Name { get; set; }
    public int BuildingId { get; set; }
    public Building Building { get; set; } = null!;
    public ICollection<Asset> Assets { get; set; } = new List<Asset>();
}