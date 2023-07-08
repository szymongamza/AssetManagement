using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Repositories;
public class FacultyRepository : GenericRepository<Faculty>, IFacultyRepository
{
    public FacultyRepository(AssetManagementContext dbContext) : base(dbContext)
    {
    }

    public async Task<QueryResult<Faculty>> ToListAsync(FacultyQuery query, CancellationToken token)
    {
        IQueryable<Faculty> queryable = _dbContext.Faculties.AsNoTracking();
        int totalItems = await queryable.CountAsync(token);
        List<Faculty> faculties = await queryable.Skip((query.Page-1) * query.ItemsPerPage).Take(query.ItemsPerPage).ToListAsync(token);

        return new QueryResult<Faculty> { Items = faculties, TotalItems = totalItems };
    }
}
