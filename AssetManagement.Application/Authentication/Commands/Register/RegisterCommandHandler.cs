using AssetManagement.Application.Authentication.Common;
using AssetManagement.Application.Common.Interfaces.Authentication;
using AssetManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AssetManagement.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public async Task<RegisterResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if (_userManager.FindByEmailAsync(command.Email) is not null)
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
