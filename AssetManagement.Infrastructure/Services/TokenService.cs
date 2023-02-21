
using AssetManagement.Application.Services;
using AssetManagement.Domain.Entities.Identity;

namespace AssetManagement.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        public string CreateToken(AppUser appUser)
        {
            return "TestToken";
        }
    }
}
