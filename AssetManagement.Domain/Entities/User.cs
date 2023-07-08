

using AssetManagement.Domain.Common;

namespace AssetManagement.Domain.Entities;
public class User : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<Asset> Assets { get; set; } = new List<Asset>();
}
