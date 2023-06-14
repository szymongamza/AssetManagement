using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces.Services;

public interface IBuildingService
{
    Task<QueryResult<Building>> ListAsync(BuildingQuery query);
    Task<BuildingResponse> AddAsync(Building building);
    Task<BuildingResponse> UpdateAsync(int id, Building building);
    Task<BuildingResponse> DeleteAsync(int id);
}