using AssetManagement.Application.Resources.Faculty;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Resources.Department;
public class DepartmentResource
{
    public int Id { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime LastModifiedUtc { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public FacultyResource Faculty { get; set; }
}
