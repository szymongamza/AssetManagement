using AssetManagementAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementAPI.Data
{
    public class RoomRepo : IRoomRepo
    {
        private readonly AppDbContext _context;

        public RoomRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateRoom(Room room)
        {
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room));
            }

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();  
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return rooms;
        }

        public async Task<Room?> GetRoomById(int id)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);
            return room;
        }

        public async Task<IEnumerable<Room>> GetRoomsByBuildingId(int id)
        {
            var rooms = await _context.Rooms.Where(x => x.BuildingId == id).ToListAsync();
            return rooms;
        }
    }
}
