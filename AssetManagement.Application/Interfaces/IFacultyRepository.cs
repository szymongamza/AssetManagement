
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces;
public interface IFacultyRepository : IGenericRepository<Faculty>
{
    public Task<List<Department>> GetDepartmentsOfFaculty(int facultyId);
    public Task<List<Building>> GetBuildingsOfFaculty(int facultyId);
}
