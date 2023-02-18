using AssetManagement.Application.Common.Interfaces.Authentication;
using AssetManagement.Application.Identity.Authentication.Common;
using AssetManagement.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AssetManagement.Application.Identity.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResult>
    {
        private readonly IIdentityService _identityService;

        public RegisterCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<RegisterResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if (await _identityService.FindByEmailAsync(command.Email, cancellationToken) is not null)
            {
                throw new Exception("User exists");
            }

            var user = new User
            {
                Email = command.Email,
                UserName = command.UserName,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            await _identityService.CreateAsync(user, command.Password,cancellationToken);

            return new RegisterResult(user);
        }
    }
}
