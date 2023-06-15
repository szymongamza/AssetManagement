using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces.Services;
public interface IDepartmentService
{
    Task<QueryResult<Department>?> ListAsync(DepartmentQuery query, CancellationToken token);
    Task<DepartmentResponse> AddAsync(Department department, CancellationToken token);
    Task<DepartmentResponse> UpdateAsync(int id, Department department, CancellationToken token);
    Task<DepartmentResponse> DeleteAsync(int id, CancellationToken token);
}