using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces.Repositories;
public interface IFacultyRepository : IGenericRepository<Faculty>
{
    Task<QueryResult<Faculty>> ToListAsync(FacultyQuery query, CancellationToken token);
}
