using System.Collections.Generic;
using System.Threading.Tasks;
using AssetManagement.Server.Data.BuildingRepo;
using AssetManagement.Server.Model;

namespace AssetManagement.Server.Tests
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

        public Task CreateBuilding(Building building)
        {
            _buildings.Add(building);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Building>> GetAllBuildings()
        {
            return Task.FromResult<IEnumerable<Building>>(_buildings);
        }

        public Task<Building?> GetBuildingById(int id)
        {
            var building = _buildings.Find(x => x.Id == id);
            return Task.FromResult(building);
        }

    }
}
