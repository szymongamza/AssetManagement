using AssetManagement.Domain.Common;

namespace AssetManagement.Domain.Entities;

public class Building : BaseAuditableEntity
{
    public string Code { get; set; } = null!;
    public string? PostCode { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public int? StreetNumber { get; set; }
    public ICollection<Faculty> Faculties { get; set; } = new List<Faculty>();
    public ICollection<Room>? Rooms { get; set; } = new List<Room>();
}