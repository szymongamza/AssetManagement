using AssetManagement.Application.Identity.Authentication.Common;
using MediatR;

namespace AssetManagement.Application.Identity.Authentication.Queries.Login
{
    public record LoginQuery : IRequest<AuthenticationResult>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
