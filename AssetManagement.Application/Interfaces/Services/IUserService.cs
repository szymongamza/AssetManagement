using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;


namespace AssetManagement.Application.Interfaces.Services;
public interface IUserService
{
    Task<QueryResult<User>> ListAsync(UserQuery query, CancellationToken token);
    Task<UserResponse> AddAsync(User user, CancellationToken token);
    Task<UserResponse> UpdateAsync(int id, User user, CancellationToken token);
    Task<UserResponse> DeleteAsync(int id, CancellationToken token);
}
