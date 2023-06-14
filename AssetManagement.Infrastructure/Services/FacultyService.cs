

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
    private readonly IFacultyRepository _faultyRepository;
    private readonly IMemoryCache _cache;

    public FacultyService(IFacultyRepository faultyRepository, IMemoryCache cache)
    {
        _faultyRepository = faultyRepository;
        _cache = cache;
    }

    public async Task<QueryResult<Faculty>?> ListAsync(FacultyQuery query, CancellationToken token)
    {
        string cacheKey = GetCacheKeyForFacultyQuery(query);

        var faculties = await _cache.GetOrCreateAsync(cacheKey, (entry) =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);
            return _faultyRepository.ToListAsync(query, token);
        });

        return faculties;
    }

    public async Task<FacultyResponse> AddAsync(Faculty faculty, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<FacultyResponse> UpdateAsync(int id, Faculty faculty, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<FacultyResponse> DeleteAsync(int id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    private string GetCacheKeyForFacultyQuery(FacultyQuery query)
    {
        string key = CacheKeys.FacultyList.ToString();
        key = string.Concat(key, "_", query.Page, "_", query.ItemsPerPage);
        return key;
    }
}
