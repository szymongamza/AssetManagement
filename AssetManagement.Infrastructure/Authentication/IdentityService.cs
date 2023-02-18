using AssetManagement.Application.Common.Interfaces.Authentication;
using AssetManagement.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Authentication
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;

        public IdentityService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.ToListAsync(cancellationToken);
            return users;
        }

        public async Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<User> CreateAsync(User user, string pass, CancellationToken cancellationToken)
        {
            var result = await _userManager.CreateAsync(user, pass);
            if (result.Succeeded)
            {
                return user;
            }

            throw new Exception(message:"Error. User not created.");
        }
    }
}
