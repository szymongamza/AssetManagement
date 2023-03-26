using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces;
public interface IDepartmentRepository : IGenericRepository<Department>
{
    public Task<List<Department>> GetDepartmentsByFacultyId(int facultyId);
    public Task<Department?> GetDepartmentByIdIncludeFaculty(int id);
}
