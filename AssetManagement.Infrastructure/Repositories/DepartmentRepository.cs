using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Repositories;
public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(AssetManagementContext dbContext) : base(dbContext)
    {

    }

    public async Task<Department?> GetDepartmentByIdIncludeFaculty(int id)
    {
        return await _dbContext.Departments.Include(b => b.Faculty).FirstOrDefaultAsync(b => b.Id == id);
    }
}
