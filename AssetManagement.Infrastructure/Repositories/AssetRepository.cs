using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Data;

namespace AssetManagement.Infrastructure.Repositories;

public class AssetRepository : GenericRepository<Asset>, IAssetRepository
{
    public AssetRepository(AssetManagementContext dbContext) : base(dbContext)
    {
    }
}