using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces.Services;

public interface IRoomService
{
    Task<QueryResult<Room>> ListAsync(RoomQuery query);
    Task<RoomResponse> AddAsync(Room room);
    Task<RoomResponse> UpdateAsync(int id, Room room);
    Task<RoomResponse> DeleteAsync(int id);
}