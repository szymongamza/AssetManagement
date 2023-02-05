

using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
