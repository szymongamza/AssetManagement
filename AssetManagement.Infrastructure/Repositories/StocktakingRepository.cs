

using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Repositories;

public class StocktakingRepository : GenericRepository<Stocktaking>, IStocktakingRepository
{
    public StocktakingRepository(AssetManagementContext dbContext) : base(dbContext)
    {
    }

    public async Task<QueryResult<Stocktaking>> ToListAsync(StocktakingQuery query, CancellationToken token)
    {
        IQueryable<Stocktaking> queryable = _dbContext.Stocktakings.Include(x=>x.AssetStocktakings).Include(x=>x.Assets)
            .AsNoTracking();
        int totalItems = await queryable.CountAsync(token);
        List<Stocktaking> stocktakings = await queryable.Skip((query.Page - 1) * query.ItemsPerPage).Take(query.ItemsPerPage).ToListAsync(token);

        return new QueryResult<Stocktaking> { Items = stocktakings, TotalItems = totalItems };
    }
}
