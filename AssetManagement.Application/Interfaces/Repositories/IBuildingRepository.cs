using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces.Repositories;
public interface IBuildingRepository : IGenericRepository<Building>
{
    Task<QueryResult<Building>> ToListAsync(BuildingQuery query, CancellationToken token);
}
