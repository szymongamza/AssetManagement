using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Repositories;

public class AssetRepository : GenericRepository<Asset>, IAssetRepository
{
    public AssetRepository(AssetManagementContext dbContext) : base(dbContext)
    {
    }

    public async Task<QueryResult<Asset>> ToListAsync(AssetQuery query, CancellationToken token)
    {
        IQueryable<Asset> queryable = _dbContext.Assets
            .Include(d => d.Room.Building.Faculties)
            .Include(d => d.Manufacturer)
            .AsNoTracking();
        int totalItems = await queryable.CountAsync(token);
        List<Asset> assets = await queryable.Skip((query.Page - 1) * query.ItemsPerPage).Take(query.ItemsPerPage).ToListAsync(token);

        return new QueryResult<Asset> { Items = assets, TotalItems = totalItems };
    }
}
