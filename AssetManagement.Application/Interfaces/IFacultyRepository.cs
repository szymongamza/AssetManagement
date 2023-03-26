
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces;
public interface IFacultyRepository : IGenericRepository<Faculty>
{
    public Task<List<Faculty>> GetFacultiesIncludeBuildingsAndDepartments();
    public Task<Faculty?> GetFacultyIncludeBuildingsAndDepartments(int facultyId);
}
