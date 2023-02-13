using AssetManagement.Domain.Entities.Identity;

namespace AssetManagement.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
