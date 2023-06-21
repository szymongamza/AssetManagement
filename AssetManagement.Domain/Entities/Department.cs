
using AssetManagement.Domain.Common;

namespace AssetManagement.Domain.Entities;

public class Department : BaseAuditableEntity
{
    public string Code { get; set; }
    public string Name { get; set; }
    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }
}