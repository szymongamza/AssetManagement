

using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Repositories;
public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(AssetManagementContext dbContext) : base(dbContext)
    {
    }

    public async Task<QueryResult<Department>> ToListAsync(DepartmentQuery query, CancellationToken token)
    {
        IQueryable<Department> queryable = _dbContext.Departments
            .Include(d => d.Faculty)
            .AsNoTracking();
        int totalItems = await queryable.CountAsync(token);
        List<Department> departments = await queryable.Skip((query.Page - 1) * query.ItemsPerPage).Take(query.ItemsPerPage).ToListAsync(token);

        return new QueryResult<Department> { Items = departments, TotalItems = totalItems };
    }
}
