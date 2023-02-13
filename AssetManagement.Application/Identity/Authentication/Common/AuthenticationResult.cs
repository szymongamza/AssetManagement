using AssetManagement.Domain.Entities.Identity;

namespace AssetManagement.Application.Identity.Authentication.Common
{
    public record AuthenticationResult(User User, string Token) : Result;
}
