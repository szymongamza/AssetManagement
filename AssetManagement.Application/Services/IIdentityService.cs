
using AssetManagement.Application.Models;
using AssetManagement.Domain.Entities.Identity;

namespace AssetManagement.Application.Services
{
    public interface IIdentityService
    {
        Task<AppUser?> FindByEmailAsync(string email);
        Task<(Result result, int userId)> CreateAsync(AppUser user, string password);
    }
}
