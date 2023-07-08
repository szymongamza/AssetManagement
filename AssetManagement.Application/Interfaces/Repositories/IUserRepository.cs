
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Interfaces.Repositories;
public interface IUserRepository : IGenericRepository<User>
{
    Task<QueryResult<User>> ToListAsync(UserQuery query, CancellationToken token);
}
