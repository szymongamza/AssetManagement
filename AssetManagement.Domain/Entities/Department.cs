
using AssetManagement.Domain.Common;

namespace AssetManagement.Domain.Entities;

public class Department : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; } = null!;
}