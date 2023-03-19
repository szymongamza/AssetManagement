
namespace AssetManagement.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime CreatedUtc { get; set; }
    public DateTime LastModifiedUtc { get; set; }
}