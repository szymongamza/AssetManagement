using AssetManagement.Domain.Common;

namespace AssetManagement.Domain.Entities;

public class Manufacturer : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<Asset> Assets { get; set; }
}