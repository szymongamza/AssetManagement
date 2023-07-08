using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces.Services;

public interface IRoomService
{
    Task<QueryResult<Room>> ListAsync(RoomQuery query, CancellationToken token);
    Task<RoomResponse> AddAsync(Room room, CancellationToken token);
    Task<RoomResponse> UpdateAsync(int id, Room room, CancellationToken token);
    Task<RoomResponse> DeleteAsync(int id, CancellationToken token);
}