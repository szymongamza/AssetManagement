using AssetManagement.Application.Common.Interfaces.Authentication;
using AssetManagement.Application.Identity.Authentication.Common;
using AssetManagement.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AssetManagement.Application.Identity.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResult>
    {
        private readonly UserManager<User> _userManager;

        public RegisterCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegisterResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if (await _userManager.FindByEmailAsync(command.Email) is not null)
            {
                throw new Exception("User exists");
            }

            var user = new User
            {
                Email = command.Email,
                UserName = command.UserName,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            await _userManager.CreateAsync(user, command.Password);

            return new RegisterResult(user);
        }
    }
}
