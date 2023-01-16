using AssetManagement.Server.Model;

namespace AssetManagement.Server.Data.BuildingRepo
{
    public interface IBuildingRepo
    {
        Task<IEnumerable<Building>> GetAllBuildings();
        Task<Building?> GetBuildingById(int id);
        Task CreateBuilding(Building building);
    }
}
