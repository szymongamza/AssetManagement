using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces.Repositories;

public interface IAssetRepository : IGenericRepository<Asset>
{
    Task<QueryResult<Asset>> ToListAsync(AssetQuery  query, CancellationToken token);
    Task<Asset> FindByQrCodeAsync(Guid guid, CancellationToken token);
}