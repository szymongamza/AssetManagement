using AssetManagementAPI.Model;

namespace AssetManagementAPI.Data
{
    public interface IRoomRepo
    {
        Task<IEnumerable<Room>> GetAllRooms();
        Task<Room?> GetRoomById(int id);
        Task CreateRoom(Room room);
        Task<IEnumerable<Room>> GetRoomsByBuildingId(int id);
    }
}
