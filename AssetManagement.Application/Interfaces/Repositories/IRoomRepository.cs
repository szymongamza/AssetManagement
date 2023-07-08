using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces.Repositories;

public interface IRoomRepository : IGenericRepository<Room>
{
    Task<QueryResult<Room>> ToListAsync(RoomQuery query, CancellationToken token);
}