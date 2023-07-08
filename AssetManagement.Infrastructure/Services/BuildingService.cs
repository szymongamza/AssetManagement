

using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;
using AssetManagement.Domain.Enums;
using AssetManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Caching.Memory;

namespace AssetManagement.Infrastructure.Services;
public class BuildingService : IBuildingService
{
    private readonly IBuildingRepository _buildingRepository;
    private readonly IFacultyRepository _facultyRepository;
    private readonly IMemoryCache _memoryCache;

    public BuildingService(IBuildingRepository buildingRepository, IMemoryCache memoryCache, IFacultyRepository facultyRepository)
    {
        _buildingRepository = buildingRepository;
        _memoryCache = memoryCache;
        _facultyRepository = facultyRepository;
    }

    public async Task<QueryResult<Building>> ListAsync(BuildingQuery query, CancellationToken token)
    {
        string cacheKey = GetCacheKeyForBuildingQuery(query);

        var buildings = await _memoryCache.GetOrCreateAsync(cacheKey, (entry) =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);
            return _buildingRepository.ToListAsync(query, token);
        });

        return buildings;
    }

    public async Task<BuildingResponse> AddAsync(Building building, CancellationToken token)
    {
        Building newBuilding = new Building()
        {
            City = building.City, Code = building.Code, PostCode = building.PostCode, Street = building.Street,
        };
        foreach (Faculty buildingFaculty in building.Faculties) 
        {
            var existingFaculty = await _facultyRepository.FindByIdAsync(buildingFaculty.Id, token);
            if (existingFaculty is null)
            {
                return new BuildingResponse("Invalid faculty.");
            }
            newBuilding.Faculties.Add(existingFaculty);
        }


        try
        {
            await _buildingRepository.AddAsync(newBuilding, token);

            return new BuildingResponse(newBuilding);
        }
        catch (Exception ex)
        {
            return new BuildingResponse($"An error occurred when adding the building: {ex.Message}");
        }
    }

    public async Task<BuildingResponse> UpdateAsync(int id, Building building, CancellationToken token)
    {
        var existingBuilding = await _buildingRepository.FindByIdAsync(id, token);

        if (existingBuilding == null)
        {
            return new BuildingResponse("Building not found");
        }

        List<Faculty> selectedFaculties = new List<Faculty>();

        foreach (Faculty buildingFaculty in building.Faculties)
        {
            var existingFaculty = await _facultyRepository.FindByIdAsync(buildingFaculty.Id, token);
            if (existingFaculty is null)
            {
                return new BuildingResponse("Invalid faculty.");
            }
            selectedFaculties.Add(existingFaculty);
        }

        existingBuilding.Faculties = selectedFaculties;
        existingBuilding.Code = building.Code;
        existingBuilding.City = building.City;
        existingBuilding.PostCode = building.PostCode;
        existingBuilding.Street = building.Street;


        try
        {
            await _buildingRepository.UpdateAsync(existingBuilding, token);
            return new BuildingResponse(existingBuilding);
        }
        catch (Exception ex)
        {
            return new BuildingResponse($"An error occurred when updating the building: {ex.Message}");
        }
    }

    public async Task<BuildingResponse> DeleteAsync(int id, CancellationToken token)
    {
        var existingBuilding = await _buildingRepository.FindByIdAsync(id, token);

        if (existingBuilding == null)
        {
            return new BuildingResponse("Building not found");
        }

        try
        {
            await _buildingRepository.DeleteAsync(existingBuilding, token);
            return new BuildingResponse(existingBuilding);
        }
        catch (Exception ex)
        {
            return new BuildingResponse($"An error occurred when deleting the building: {ex.Message}");
        }
    }

    private static string GetCacheKeyForBuildingQuery(BuildingQuery query)
    {
        string key = CacheKeys.BuildingList.ToString();
        key = string.Concat(key, "_", query.Page, "_", query.ItemsPerPage);
        return key;
    }
}
