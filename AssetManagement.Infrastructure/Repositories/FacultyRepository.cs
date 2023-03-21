using System.Security.Cryptography.X509Certificates;
using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Repositories;
public class FacultyRepository : GenericRepository<Faculty>, IFacultyRepository
{
    public FacultyRepository(AssetManagementContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Department>> GetDepartmentsOfFaculty(int facultyId)
    {
        return await _dbContext.Departments.Where(x => x.FacultyId == facultyId).ToListAsync();
    }

    public async Task<List<Building>> GetBuildingsOfFaculty(int facultyId)
    {
        var faculty = await _dbContext.Faculties.Where(x => x.Id == facultyId).Include(x=> x.Buildings).FirstOrDefaultAsync();

        return faculty.Buildings.ToList();

    }
}
