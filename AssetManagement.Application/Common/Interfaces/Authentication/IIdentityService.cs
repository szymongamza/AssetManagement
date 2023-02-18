
using AssetManagement.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace AssetManagement.Application.Common.Interfaces.Authentication
{
    public interface IIdentityService
    {
        Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken);
        Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken);
        Task<User> CreateAsync(User user,string pass, CancellationToken cancellationToken);
    }
}
