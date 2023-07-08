
using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Repositories;
public class RoomRepository : GenericRepository<Room>, IRoomRepository
{
    public RoomRepository(AssetManagementContext dbContext) : base(dbContext)
    {
    }

    public async Task<QueryResult<Room>> ToListAsync(RoomQuery query, CancellationToken token)
    {
        IQueryable<Room> queryable = _dbContext.Rooms
            .Include(d => d.Building.Faculties)
            .AsNoTracking();
        int totalItems = await queryable.CountAsync(token);
        List<Room> rooms = await queryable.Skip((query.Page - 1) * query.ItemsPerPage).Take(query.ItemsPerPage).ToListAsync(token);

        return new QueryResult<Room> { Items = rooms, TotalItems = totalItems };
    }
    public new async Task<Room> FindByIdAsync (int id, CancellationToken token)
    {
        var room = await _dbContext.Rooms.Include(x=>x.Assets).FirstOrDefaultAsync(d => d.Id == id);
        return room;
    }
}
