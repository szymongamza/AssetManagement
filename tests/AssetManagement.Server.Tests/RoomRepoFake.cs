using System.Collections.Generic;
using System.Threading.Tasks;
using AssetManagement.Server.Data.RoomRepo;
using AssetManagement.Server.Model;

namespace AssetManagement.Server.Tests
{
    public class RoomRepoFake : IRoomRepo
    {
        private readonly List<Room> _rooms;

        public RoomRepoFake()
        {
            _rooms = new List<Room>()
            {
                new Room(){Id = 1, BuildingId = 1, Floor = 3, Name = "301"},
                new Room(){Id = 1, BuildingId = 1, Floor = 3, Name = "302"},
                new Room(){Id = 2, BuildingId = 2, Floor = 3, Name = "301"},
                new Room(){Id = 3, BuildingId = 3, Floor = 3, Name = "301"},
            };
        }
        public Task CreateRoom(Room room)

        {
            _rooms.Add(room);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Room>> GetAllRooms()
        {
            return Task.FromResult<IEnumerable<Room>>(_rooms);
        }

        public Task<Room?> GetRoomById(int id)
        {
            return Task.FromResult(_rooms.Find(x => x.Id == id));
        }

        public Task<IEnumerable<Room>> GetRoomsByBuildingId(int id)
        {
            return Task.FromResult<IEnumerable<Room>>(_rooms.FindAll(x => x.BuildingId == id));
        }
    }
}
