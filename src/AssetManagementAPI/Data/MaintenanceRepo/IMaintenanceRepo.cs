using AssetManagementAPI.Model;

namespace AssetManagementAPI.Data
{
    public interface IMaintenanceRepo
    {
        Task<IEnumerable<Maintenance>> GetMaintenancesOfProduct(int productId);
        Task<Maintenance?> GetMaintenanceById(int id);
        Task CreateMaintenance(Maintenance maintenance);
        Task<Maintenance?> GetLastMaintenanceOfProduct(int productId);
    }
}
