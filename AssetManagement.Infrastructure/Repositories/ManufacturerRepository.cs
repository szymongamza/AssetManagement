using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Data;

namespace AssetManagement.Infrastructure.Repositories;

public class ManufacturerRepository : GenericRepository<Manufacturer>, IManufacturerRepository
{
    protected ManufacturerRepository(AssetManagementContext dbContext) : base(dbContext)
    {
    }
}