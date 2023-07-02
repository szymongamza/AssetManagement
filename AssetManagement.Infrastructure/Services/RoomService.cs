
using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;
using AssetManagement.Domain.Enums;
using AssetManagement.Infrastructure.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace AssetManagement.Infrastructure.Services;
public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IBuildingRepository _buildingRepository;
    private readonly IMemoryCache _memoryCache;

    public RoomService(IRoomRepository roomRepository, IMemoryCache memoryCache, IBuildingRepository buildingRepository)
    {
        _roomRepository = roomRepository;
        _memoryCache = memoryCache;
        _buildingRepository = buildingRepository;
    }

    public async Task<QueryResult<Room>> ListAsync(RoomQuery query, CancellationToken token)
    {
        string cacheKey = GetCacheKeyForRoomQuery(query);

        var rooms = await _memoryCache.GetOrCreateAsync(cacheKey, (entry) =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);
            return _roomRepository.ToListAsync(query, token);
        });

        return rooms;
    }

    public async Task<RoomResponse> AddAsync(Room room, CancellationToken token)
    {
        var existingBuilding = await _buildingRepository.FindByIdAsync(room.BuildingId, token);
        if (existingBuilding == null)
        {
            return new RoomResponse("Invalid building.");
        }
        try
        {
            await _roomRepository.AddAsync(room, token);

            return new RoomResponse(room);
        }
        catch (Exception ex)
        {
            return new RoomResponse($"An error occurred when adding the room: {ex.Message}");
        }
    }

    public async Task<RoomResponse> UpdateAsync(int id, Room room, CancellationToken token)
    {
        var existingRoom = await _roomRepository.FindByIdAsync(id, token);

        if (existingRoom == null)
        {
            return new RoomResponse("Room not found");
        }
        var existingBuilding = await _buildingRepository.FindByIdAsync(room.BuildingId, token);
        if (existingBuilding == null)
        {
            return new RoomResponse("Invalid building.");
        }

        existingRoom.BuildingId = room.BuildingId;
        existingRoom.Code = room.Code;
        existingRoom.Name = room.Name;

        try
        {
            await _roomRepository.UpdateAsync(existingRoom, token);
            return new RoomResponse(existingRoom);
        }
        catch (Exception ex)
        {
            return new RoomResponse($"An error occurred when updating the room: {ex.Message}");
        }
    }

    public async Task<RoomResponse> DeleteAsync(int id, CancellationToken token)
    {
        var existingRoom = await _roomRepository.FindByIdAsync(id, token);

        if (existingRoom == null)
        {
            return new RoomResponse("Room not found");
        }

        try
        {
            await _roomRepository.DeleteAsync(existingRoom, token);
            return new RoomResponse(existingRoom);
        }
        catch (Exception ex)
        {
            return new RoomResponse($"An error occurred when deleting the room: {ex.Message}");
        }
    }
    private static string GetCacheKeyForRoomQuery(RoomQuery query)
    {
        string key = CacheKeys.RoomList.ToString();
        key = string.Concat(key, "_", query.Page, "_", query.ItemsPerPage);
        return key;
    }
}
