using Localisation.API.Model;

namespace Localisation.API.Data
{
    public interface IBuildingRepo
    {
        bool SaveChanges();
        IEnumerable<Building> GetAllBuildings();
    }
}
