using Localisation.API.Model;

namespace Localisation.API.Data
{
    public interface IBuildingRepo
    {
        Task<IEnumerable<Building>> GetAllBuildings();
        Task<Building> GetBuildingById(int id);
        Task CreateBuilding(Building building);
        Task<bool> IdExist(int id);
    }
}
