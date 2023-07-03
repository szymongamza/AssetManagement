
using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;
using AssetManagement.Domain.Enums;
using Microsoft.Extensions.Caching.Memory;

namespace AssetManagement.Infrastructure.Services;

public class ManufacturerService : IManufacturerService
{   
    private readonly IManufacturerRepository _manufacturerRepository;
    private readonly IMemoryCache _memoryCache;

    public ManufacturerService(IManufacturerRepository manufacturerRepository, IMemoryCache memoryCache)
    {
        _manufacturerRepository= manufacturerRepository;
        _memoryCache= memoryCache;
    }
    public async Task<QueryResult<Manufacturer>> ListAsync(ManufacturerQuery query, CancellationToken token)
    {
        string cacheKey = GetCacheKeyForManufacturerQuery(query);

        var faculties = await _memoryCache.GetOrCreateAsync(cacheKey, (entry) =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);
            return _manufacturerRepository.ToListAsync(query, token);
        });

        return faculties;
    }
    public async Task<ManufacturerResponse> AddAsync(Manufacturer manufacturer, CancellationToken token)
    {
        try
        {
            await _manufacturerRepository.AddAsync(manufacturer, token);

            return new ManufacturerResponse(manufacturer);
        }
        catch (Exception ex)
        {
            return new ManufacturerResponse($"An error occurred when adding the manufacturer: {ex.Message}");
        }
    }

    public async Task<ManufacturerResponse> UpdateAsync(int id, Manufacturer manufacturer, CancellationToken token)
    {
        var existingManufacturer = await _manufacturerRepository.FindByIdAsync(id, token);

        if (existingManufacturer == null)
        {
            return new ManufacturerResponse("Manufacturer not found");
        }

        existingManufacturer.PhoneNumber = manufacturer.PhoneNumber;
        existingManufacturer.Name = manufacturer.Name;
        existingManufacturer.Email = manufacturer.Email;

        try
        {
            await _manufacturerRepository.UpdateAsync(existingManufacturer, token);
            return new ManufacturerResponse(existingManufacturer);
        }
        catch (Exception ex)
        {
            return new ManufacturerResponse($"An error occurred when updating the manufacturer: {ex.Message}");
        }
    }

    public async Task<ManufacturerResponse> DeleteAsync(int id, CancellationToken token)
    {
        var existingManufacturer = await _manufacturerRepository.FindByIdAsync(id, token);

        if (existingManufacturer == null)
        {
            return new ManufacturerResponse("Manufacturer not found");
        }

        try
        {
            await _manufacturerRepository.DeleteAsync(existingManufacturer, token);
            return new ManufacturerResponse(existingManufacturer);
        }
        catch (Exception ex)
        {
            return new ManufacturerResponse($"An error occurred when deleting the manufacturer: {ex.Message}");
        }
    }
    private string GetCacheKeyForManufacturerQuery(ManufacturerQuery query)
    {
        string key = CacheKeys.ManufacturerList.ToString();
        key = string.Concat(key, "_", query.Page, "_", query.ItemsPerPage);
        return key;
    }
}
