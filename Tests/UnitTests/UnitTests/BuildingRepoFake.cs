using Localisation.API.Data;
using Localisation.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class BuildingRepoFake : IBuildingRepo
    {
        private readonly List<Building> _buildings;

        public BuildingRepoFake()
        {
            _buildings = new List<Building>()
            {
                new Building() { Id = 1, Name = "Wydział Inżynierii Metali i Informatyki Przemysłowej", BuildingCode = "B5", MinFloor = -1, MaxFloor = 8},
                new Building() { Id = 2, Name = "Wydział Inżynierii Mechanicznej i Robotyki", BuildingCode = "B1", MinFloor = -1, MaxFloor = 4 },
                new Building() { Id = 3, Name = "Wydział Inżynierii Mechanicznej i Robotyki", BuildingCode = "B2", MinFloor = -1, MaxFloor = 4 }
            };
        }
#pragma warning disable CS1998 // Metoda asynchroniczna nie zawiera operatorów „await” i zostanie uruchomiona synchronicznie
        public async Task CreateBuilding(Building building)
        {
            _buildings.Add(building);
        }

        public async Task<IEnumerable<Building>> GetAllBuildings()
        {
            return _buildings;
        }

        public async Task<Building?> GetBuildingById(int id)
        {
            var building = _buildings.Find(x => x.Id == id);
            return building;
        }
#pragma warning restore CS1998 // Metoda asynchroniczna nie zawiera operatorów „await” i zostanie uruchomiona synchronicznie
    }
}
