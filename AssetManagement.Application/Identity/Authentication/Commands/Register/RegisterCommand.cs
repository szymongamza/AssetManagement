using AssetManagement.Application.Identity.Authentication.Common;
using MediatR;

namespace AssetManagement.Application.Identity.Authentication.Commands.Register
{
    public record RegisterCommand : IRequest<RegisterResult>
    {
        public string UserName { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string Password { get; init; } = null!;


    }


}
