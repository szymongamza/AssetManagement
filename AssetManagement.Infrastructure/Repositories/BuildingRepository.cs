using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Repositories;
public class BuildingRepository : GenericRepository<Building>, IBuildingRepository
{
    public BuildingRepository(AssetManagementContext dbContext) : base(dbContext)
    {
        
    }

    public async Task<List<Building>> GetAllBuildingsIncludeFaculties()
    {
        return await _dbContext.Buildings.Include(b => b.Faculties).ToListAsync();
    }

    public async Task<Building?> GetBuildingByIdIncludeFaculties(int id)
    {
        return await _dbContext.Buildings.Include(b => b.Faculties).FirstOrDefaultAsync(b=>b.Id == id);
    }
}
