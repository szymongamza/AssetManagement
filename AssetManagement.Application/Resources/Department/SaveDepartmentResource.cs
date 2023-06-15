

namespace AssetManagement.Application.Resources.Department;

public class SaveDepartmentResource
{
    public string? Code { get; set; }
    public string Name { get; set; } = null!;
    public int FacultyId { get; set; }
}
