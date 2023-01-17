using AssetManagement.Core.Entities;

namespace AssetManagement.Core.Interfaces
{
    public interface IMaintenanceRepo
    {
        Task<IEnumerable<Maintenance>> GetMaintenancesOfProduct(int productId);
        Task<Maintenance?> GetMaintenanceById(int id);
        Task CreateMaintenance(Maintenance maintenance);
        Task<Maintenance?> GetLastMaintenanceOfProduct(int productId);
    }
}
