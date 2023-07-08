using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces.Services;

public interface IManufacturerService
{
    Task<QueryResult<Manufacturer>> ListAsync(ManufacturerQuery query, CancellationToken token);
    Task<ManufacturerResponse> AddAsync(Manufacturer manufacturer, CancellationToken token);
    Task<ManufacturerResponse> UpdateAsync(int id, Manufacturer manufacturer, CancellationToken token);
    Task<ManufacturerResponse> DeleteAsync(int id, CancellationToken token);
}