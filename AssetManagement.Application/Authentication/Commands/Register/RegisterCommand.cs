using AssetManagement.Application.Authentication.Common;
using MediatR;

namespace AssetManagement.Application.Authentication.Commands.Register
{
    public record RegisterCommand : IRequest<RegisterResult>
    {
        public string? UserName { get; init;}
        public string? Email { get; init;}
        public string? Password { get; init;}


    }


}
