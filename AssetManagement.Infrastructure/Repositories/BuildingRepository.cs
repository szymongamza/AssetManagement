using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Data;

namespace AssetManagement.Infrastructure.Repositories;
public class BuildingRepository : GenericRepository<Building>, IBuildingRepository
{
    protected BuildingRepository(AssetManagementContext dbContext) : base(dbContext)
    {
    }
}
