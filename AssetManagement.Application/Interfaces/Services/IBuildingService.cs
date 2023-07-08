using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces.Services;

public interface IBuildingService
{
    Task<QueryResult<Building>> ListAsync(BuildingQuery query, CancellationToken token);
    Task<BuildingResponse> AddAsync(Building building, CancellationToken token);
    Task<BuildingResponse> UpdateAsync(int id, Building building, CancellationToken token);
    Task<BuildingResponse> DeleteAsync(int id, CancellationToken token);
}