using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Data;

namespace AssetManagement.Infrastructure.Repositories;

public class ManufacturerRepository : GenericRepository<Manufacturer>, IManufacturerRepository
{
    public ManufacturerRepository(AssetManagementContext dbContext) : base(dbContext)
    {
    }
}