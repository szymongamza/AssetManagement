using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;
using AssetManagement.Domain.Enums;
using Microsoft.Extensions.Caching.Memory;

namespace AssetManagement.Infrastructure.Services;
public class FacultyService : IFacultyService
{
    private readonly IFacultyRepository _facultyRepository;
    private readonly IMemoryCache _cache;

    public FacultyService(IFacultyRepository facultyRepository, IMemoryCache cache)
    {
        _facultyRepository = facultyRepository;
        _cache = cache;
    }

    public async Task<QueryResult<Faculty>> ListAsync(FacultyQuery query, CancellationToken token)
    {
        string cacheKey = GetCacheKeyForFacultyQuery(query);

        var faculties = await _cache.GetOrCreateAsync(cacheKey, (entry) =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);
            return _facultyRepository.ToListAsync(query, token);
        });

        return faculties;
    }

    public async Task<FacultyResponse> AddAsync(Faculty faculty, CancellationToken token)
    {
        try
        {
            await _facultyRepository.AddAsync(faculty, token);

            return new FacultyResponse(faculty);
        }
        catch (Exception ex)
        {
            return new FacultyResponse($"An error occurred when adding the faculty: {ex.Message}");
        }
    }

    public async Task<FacultyResponse> UpdateAsync(int id, Faculty faculty, CancellationToken token)
    {
        var existingFaculty = await _facultyRepository.FindByIdAsync(id, token);

        if (existingFaculty == null)
        {
            return new FacultyResponse("Faculty not found");
        }

        existingFaculty.Code = faculty.Code;
        existingFaculty.Name = faculty.Name;

        try
        {
            await _facultyRepository.UpdateAsync(existingFaculty, token);
            return new FacultyResponse(existingFaculty);
        }
        catch (Exception ex)
        {
            return new FacultyResponse($"An error occurred when updating the faculty: {ex.Message}");
        }
    }

    public async Task<FacultyResponse> DeleteAsync(int id, CancellationToken token)
    {
        var existingFaculty = await _facultyRepository.FindByIdAsync(id, token);

        if (existingFaculty == null)
        {
            return new FacultyResponse("Faculty not found");
        }

        try
        {
            await _facultyRepository.DeleteAsync(existingFaculty, token);
            return new FacultyResponse(existingFaculty);
        }
        catch (Exception ex)
        {
            return new FacultyResponse($"An error occurred when deleting the faculty: {ex.Message}");
        }
    }

    private string GetCacheKeyForFacultyQuery(FacultyQuery query)
    {
        string key = CacheKeys.FacultyList.ToString();
        key = string.Concat(key, "_", query.Page, "_", query.ItemsPerPage);
        return key;
    }
}
