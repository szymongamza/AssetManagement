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

    public async Task<List<Faculty>> GetFacultiesIncludeBuildingsAndDepartments()
    {
        return await _dbContext.Faculties
            .Include(x => x.Buildings)
            .AsSplitQuery()
            .Include(x=>x.Departments)
            .AsSplitQuery()
            .ToListAsync();
    }

    public async Task<Faculty?> GetFacultyIncludeBuildingsAndDepartments(int facultyId)
    {
        return await _dbContext.Faculties
            .Where(x => x.Id == facultyId)
            .Include(x => x.Buildings)
            .AsSplitQuery()
            .Include(x => x.Departments)
            .AsSplitQuery()
            .FirstOrDefaultAsync();
    }
}
