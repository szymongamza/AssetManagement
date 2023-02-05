using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}
