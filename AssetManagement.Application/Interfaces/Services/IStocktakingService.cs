using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces.Services;
public interface IStocktakingService
{
    Task<QueryResult<Stocktaking>> ListAsync(StocktakingQuery query, CancellationToken token);
    Task<StocktakingResponse> AddAsync(int roomId, CancellationToken token);
    Task<StocktakingResponse> UpdateAsync(int id, Stocktaking stocktaking, CancellationToken token);
    Task<StocktakingResponse> DeleteAsync(int id, CancellationToken token);
}
