using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces.Repositories;

public interface IManufacturerRepository : IGenericRepository<Manufacturer>
{
    Task<QueryResult<Manufacturer>> ToListAsync(ManufacturerQuery query, CancellationToken token);
}