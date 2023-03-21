using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Data;

namespace AssetManagement.Infrastructure.Repositories;

public class MaintenanceRepository : GenericRepository<Maintenance>, IMaintenanceRepository
{
    public MaintenanceRepository(AssetManagementContext dbContext) : base(dbContext)
    {
    }
}