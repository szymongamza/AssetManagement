using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(AssetManagementContext dbContext) : base(dbContext)
    {
    }

    public async Task<QueryResult<User>> ToListAsync(UserQuery query, CancellationToken token)
    {
        IQueryable<User> queryable = _dbContext.Users.AsNoTracking();
        int totalItems = await queryable.CountAsync(token);
        List<User> users = await queryable.Skip((query.Page - 1) * query.ItemsPerPage).Take(query.ItemsPerPage).ToListAsync(token);

        return new QueryResult<User> { Items = users, TotalItems = totalItems };
    }
}