
using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;
using AssetManagement.Domain.Enums;
using AssetManagement.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;

namespace AssetManagement.Infrastructure.Services;

public class AssetService : IAssetService
{
    private readonly IAssetRepository _assetRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IMemoryCache _memoryCache;
    private readonly IMapper _mapper;
    public AssetService(IAssetRepository assetRepository, IRoomRepository roomRepository, IMemoryCache memoryCache, IMapper mapper)
    {
        _assetRepository = assetRepository;
        _roomRepository = roomRepository;
        _memoryCache = memoryCache;
        _mapper = mapper;
    }
    public async Task<QueryResult<Asset>> ListAsync(AssetQuery query, CancellationToken token)
    {
        string cacheKey = GetCacheKeyForAssetQuery(query);

        var assets = await _memoryCache.GetOrCreateAsync(cacheKey, (entry) =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);
            return _assetRepository.ToListAsync(query, token);
        });

        return assets;
    }

    public async Task<AssetResponse> AddAsync(Asset asset, CancellationToken token)
    {
        var existingRoom = await _roomRepository.FindByIdAsync(asset.RoomId, token);
        if (existingRoom == null)
        {
            return new AssetResponse("Invalid room.");
        }
        try
        {
            await _assetRepository.AddAsync(asset, token);

            return new AssetResponse(asset);
        }
        catch (Exception ex)
        {
            return new AssetResponse($"An error occurred when adding the asset: {ex.Message}");
        }
    }

    public async Task<AssetResponse> UpdateAsync(int id, Asset asset, CancellationToken token)
    {
        var existingAsset = await _assetRepository.FindByIdAsync(id, token);

        if (existingAsset == null)
        {
            return new AssetResponse("Asset not found");
        }
        var existingRoom = await _roomRepository.FindByIdAsync(asset.RoomId, token);
        if (existingRoom == null)
        {
            return new AssetResponse("Invalid room.");
        }
        asset.QrCode = existingAsset.QrCode;
        existingAsset = _mapper.Map(asset, existingAsset);
        

        try
        {
            await _assetRepository.UpdateAsync(existingAsset, token);
            return new AssetResponse(existingAsset);
        }
        catch (Exception ex)
        {
            return new AssetResponse($"An error occurred when updating the asset: {ex.Message}");
        }
    }

    public async Task<AssetResponse> DeleteAsync(int id, CancellationToken token)
    {
        var existingAsset = await _assetRepository.FindByIdAsync(id, token);

        if (existingAsset == null)
        {
            return new AssetResponse("Asset not found");
        }

        try
        {
            await _assetRepository.DeleteAsync(existingAsset, token);
            return new AssetResponse(existingAsset);
        }
        catch (Exception ex)
        {
            return new AssetResponse($"An error occurred when deleting the asset: {ex.Message}");
        }
    }

    private static string GetCacheKeyForAssetQuery(AssetQuery query)
    {
        string key = CacheKeys.AssetList.ToString();
        key = string.Concat(key, "_", query.Page, "_", query.ItemsPerPage);
        return key;
    }

}
