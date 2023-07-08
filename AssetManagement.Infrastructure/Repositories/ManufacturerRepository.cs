
using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Repositories;

public class ManufacturerRepository : GenericRepository<Manufacturer>, IManufacturerRepository
{
    public ManufacturerRepository(AssetManagementContext dbContext) : base(dbContext)
    {
    }

    public async Task<QueryResult<Manufacturer>> ToListAsync(ManufacturerQuery query, CancellationToken token)
    {
        IQueryable<Manufacturer> queryable = _dbContext.Manufacturers.AsNoTracking();
        int totalItems = await queryable.CountAsync(token);
        List<Manufacturer> manufacturers = await queryable.Skip((query.Page - 1) * query.ItemsPerPage).Take(query.ItemsPerPage).ToListAsync(token);

        return new QueryResult<Manufacturer> { Items = manufacturers, TotalItems = totalItems };
    }
}
