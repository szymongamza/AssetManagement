using AssetManagement.Domain.Entities;

namespace AssetManagement.Api.Dtos
{
    public class DepartmentCreateDto
    {
        public string Name { get; set; } = null!;
        public int FacultyId { get; set; }
    }
}
