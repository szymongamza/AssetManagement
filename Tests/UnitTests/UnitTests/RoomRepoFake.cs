using Localisation.API.Data;
using Localisation.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
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
#pragma warning disable CS1998 // Metoda asynchroniczna nie zawiera operatorów „await” i zostanie uruchomiona synchronicznie
        public async Task CreateRoom(Room room)

        {
            _rooms.Add(room);
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return _rooms;
        }

        public async Task<Room?> GetRoomById(int id)
        {
            return _rooms.Find(x => x.Id == id);
        }

        public async Task<IEnumerable<Room>> GetRoomsByBuildingId(int id)
        {
            return _rooms.FindAll(x => x.BuildingId == id);
        }
#pragma warning restore CS1998 // Metoda asynchroniczna nie zawiera operatorów „await” i zostanie uruchomiona synchronicznie
    }
}
