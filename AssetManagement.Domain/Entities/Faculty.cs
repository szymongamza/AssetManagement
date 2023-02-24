using AssetManagement.Domain.Common;

namespace AssetManagement.Domain.Entities;

public class Faculty : BaseAuditableEntity
{
    public string FacultyCode { get; set; } = null!;
    public string FacultyName { get; set; } = null!;
    public ICollection<Department>? Departments { get; set; } = new List<Department>();
}