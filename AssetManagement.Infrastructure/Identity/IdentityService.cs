using AssetManagement.Application.Models;
using AssetManagement.Application.Services;
using AssetManagement.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace AssetManagement.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<AppUser> _userManager;

        public IdentityService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppUser?> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<(Result result, string? userId)> CreateAsync(AppUser user, string password)
        {
            var identityResult = await _userManager.CreateAsync(user, password);
            if (identityResult.Succeeded)
            {
                var result = Result.Success();
                return (result,user.Id);
            }
            else
            {
                var identityErrors = identityResult.Errors;
                List<string> errors = new List<string>();
                foreach (var error in identityErrors)
                {
                    errors.Add(error.Description);
                }
                var result = Result.Failure(errors);
                return (result,null);
            }
        }
    }
}
