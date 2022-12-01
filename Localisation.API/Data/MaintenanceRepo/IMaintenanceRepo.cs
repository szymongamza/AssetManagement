using Localisation.API.Model;

namespace Localisation.API.Data
{
    public interface IMaintenanceRepo
    {
        Task<IEnumerable<Maintenance>> GetMaintenancesOfProduct(int productId);
        Task<Maintenance?> GetMaintenanceById(int id);
        Task CreateMaintenance(Maintenance maintenance);
        Task GetLastMaintenanceOfProduct(int productId);
    }
}
