using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces.Services;
public interface IDepartmentService
{
    Task<QueryResult<Department>> ListAsync(DepartmentQuery query);
    Task<DepartmentResponse> AddAsync(Department department);
    Task<DepartmentResponse> UpdateAsync(int id, Department department);
    Task<DepartmentResponse> DeleteAsync(int id);
}