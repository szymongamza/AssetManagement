using Localisation.API.Model;

namespace Localisation.API.Data
{
    public interface IRoomRepo
    {
        Task<IEnumerable<Room>> GetAllRooms();
        Task<Room> GetRoomById(int id);
        Task CreateRoom(Room room);
        Task<IEnumerable<Room>> GetRoomsByBuildingId(int id);
    }
}
