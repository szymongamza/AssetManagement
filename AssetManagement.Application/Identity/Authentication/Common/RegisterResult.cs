using AssetManagement.Domain.Entities.Identity;

namespace AssetManagement.Application.Identity.Authentication.Common
{
    public record RegisterResult(User User) : Result;
}