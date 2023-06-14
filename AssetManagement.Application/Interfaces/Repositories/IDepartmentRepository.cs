using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces.Repositories;
public interface IDepartmentRepository : IGenericRepository<Department>
{
    Task<QueryResult<Department>> ToListAsync(DepartmentQuery query, CancellationToken token);
}
