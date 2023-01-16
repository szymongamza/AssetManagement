using AssetManagement.Server.Model;

namespace AssetManagement.Server.Data.MaintenanceRepo
{
    public interface IMaintenanceRepo
    {
        Task<IEnumerable<Maintenance>> GetMaintenancesOfProduct(int productId);
        Task<Maintenance?> GetMaintenanceById(int id);
        Task CreateMaintenance(Maintenance maintenance);
        Task<Maintenance?> GetLastMaintenanceOfProduct(int productId);
    }
}
