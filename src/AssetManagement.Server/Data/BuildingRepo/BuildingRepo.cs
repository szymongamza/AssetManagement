using AssetManagement.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Server.Data.BuildingRepo
{
    public class BuildingRepo : IBuildingRepo
    {
        private readonly AppDbContext _context;

        public BuildingRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateBuilding(Building building)
        {
            if (building == null)
            {
                throw new ArgumentNullException(nameof(building));
            }

            _context.Buildings.Add(building);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Building>> GetAllBuildings()
        {
            var buildings = await _context.Buildings.ToListAsync();
            return buildings;
        }

        public async Task<Building?> GetBuildingById(int id)
        {
            var building = await _context.Buildings.FirstOrDefaultAsync(x => x.Id == id);
            return building;
        }
    }
}
