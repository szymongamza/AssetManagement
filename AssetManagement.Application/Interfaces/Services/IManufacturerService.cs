using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces.Services;

public interface IManufacturerService
{
    Task<QueryResult<Manufacturer>> ListAsync(ManufacturerQuery query);
    Task<ManufacturerResponse> AddAsync(Manufacturer manufacturer);
    Task<ManufacturerResponse> UpdateAsync(int id, Manufacturer manufacturer);
    Task<ManufacturerResponse> DeleteAsync(int id);
}