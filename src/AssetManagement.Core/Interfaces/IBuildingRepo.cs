using AssetManagement.Core.Entities;

namespace AssetManagement.Core.Interfaces
{
    public interface IBuildingRepo
    {
        Task<IEnumerable<Building>> GetAllBuildings();
        Task<Building?> GetBuildingById(int id);
        Task CreateBuilding(Building building);
    }
}
