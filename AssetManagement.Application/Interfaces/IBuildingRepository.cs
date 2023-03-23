using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces;
public interface IBuildingRepository : IGenericRepository<Building>
{
    public Task<List<Building>> GetAllBuildingsIncludeFaculties();
    public Task<Building?> GetBuildingByIdIncludeFaculties(int id);
}
