using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces.Services;

public interface IAssetService
{
    Task<QueryResult<Asset>> ListAsync(AssetQuery query);
    Task<AssetResponse> AddAsync(Asset asset);
    Task<AssetResponse> UpdateAsync(int id, Asset asset);
    Task<AssetResponse> DeleteAsync(int id);
}