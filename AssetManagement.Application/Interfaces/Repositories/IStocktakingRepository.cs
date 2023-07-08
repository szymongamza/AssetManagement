
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces.Repositories;

public interface IStocktakingRepository : IGenericRepository<Stocktaking>
{
    Task<QueryResult<Stocktaking>> ToListAsync(StocktakingQuery query, CancellationToken token);
}
