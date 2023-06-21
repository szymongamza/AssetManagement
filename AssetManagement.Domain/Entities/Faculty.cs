using AssetManagement.Domain.Common;

namespace AssetManagement.Domain.Entities;

public class Faculty : BaseAuditableEntity
{
    public string Code { get; set; }
    public string Name { get; set; }
    public ICollection<Department> Departments { get; set; } = new List<Department>();
    public ICollection<Building> Buildings { get; set; } = new List<Building>();
}