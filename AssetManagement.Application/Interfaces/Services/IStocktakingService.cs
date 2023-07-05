using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces.Services;
public interface IStocktakingService
{
    Task<QueryResult<Stocktaking>> ListAsync(StocktakingQuery query, CancellationToken token);
    Task<StocktakingResponse> OpenStockTakingAsync(int roomId, CancellationToken token);
    Task<StocktakingResponse> RegisterAssetAsync(Guid guid, CancellationToken token);
    Task<StocktakingResponse> CloseStocktakingAsync(int id, CancellationToken token);
    Task<StocktakingResponse> DeleteAsync(int id, CancellationToken token);
}
