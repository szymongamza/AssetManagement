using AssetManagementAPI.Model;

namespace AssetManagementAPI.Data
{
    public interface IBuildingRepo
    {
        Task<IEnumerable<Building>> GetAllBuildings();
        Task<Building?> GetBuildingById(int id);
        Task CreateBuilding(Building building);
    }
}
