using AssetManagement.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Server.Data.MaintenanceRepo
{
    public class MaintenanceRepo : IMaintenanceRepo
    {
        private readonly AppDbContext _context;

        public MaintenanceRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateMaintenance(Maintenance maintenance)
        {
            if(maintenance == null)
            {
                throw new ArgumentNullException(nameof(maintenance));
            }
            _context.Maintenances.Add(maintenance);
            await _context.SaveChangesAsync();
        }

        public async Task<Maintenance?> GetLastMaintenanceOfProduct(int productId)
        {
            var maintenance = await _context.Maintenances.OrderByDescending(x => x.DateEnd).FirstOrDefaultAsync();
            return maintenance;
        }

        public async Task<Maintenance?> GetMaintenanceById(int id)
        {
            var maintenance = await _context.Maintenances.FirstOrDefaultAsync(x=> x.Id == id);
            return maintenance;
        }

        public async Task<IEnumerable<Maintenance>> GetMaintenancesOfProduct(int productId)
        {
            var maintenances = await _context.Maintenances.ToListAsync();
            return maintenances;
        }
    }
}
