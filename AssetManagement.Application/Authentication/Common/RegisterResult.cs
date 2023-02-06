using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Authentication.Common
{
    public record RegisterResult(User User) : Result;
}