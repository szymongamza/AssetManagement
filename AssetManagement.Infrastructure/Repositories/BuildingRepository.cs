

using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Repositories;
public class BuildingRepository : GenericRepository<Building>, IBuildingRepository
{
    public BuildingRepository(AssetManagementContext dbContext) : base(dbContext)
    {
    }

    public async Task<QueryResult<Building>> ToListAsync(BuildingQuery query, CancellationToken token)
    {
        IQueryable<Building> queryable = _dbContext.Buildings
            .Include(d => d.Faculties)
            .AsNoTracking();
        int totalItems = await queryable.CountAsync(token);
        List<Building> buildings = await queryable.Skip((query.Page - 1) * query.ItemsPerPage).Take(query.ItemsPerPage).ToListAsync(token);

        return new QueryResult<Building> { Items = buildings, TotalItems = totalItems };
    }
}
