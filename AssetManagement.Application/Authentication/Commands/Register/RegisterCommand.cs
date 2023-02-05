using AssetManagement.Application.Authentication.Common;
using MediatR;

namespace AssetManagement.Application.Authentication.Commands.Register
{
    public record RegisterCommand : IRequest<AuthenticationResult>
    {
        public string? FirstName { get; init;}
        public string? LastName { get; init;}
        public string? Email { get; init;}
        public string? Password { get; init;}


    }


}
