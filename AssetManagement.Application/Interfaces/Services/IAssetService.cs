using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces.Services;

public interface IAssetService
{
    Task<QueryResult<Asset>> ListAsync(AssetQuery query, CancellationToken token);
    Task<AssetResponse> AddAsync(Asset asset, CancellationToken token);
    Task<AssetResponse> UpdateAsync(int id, Asset asset, CancellationToken token);
    Task<AssetResponse> DeleteAsync(int id, CancellationToken token);
}