using AssetManagement.Application.Common.Interfaces.Authentication;
using AssetManagement.Application.Identity.Authentication.Common;
using AssetManagement.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AssetManagement.Application.Identity.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
    {
        private readonly UserManager<User> _userManager;

        public LoginQueryHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(query.Email);


            if (user != null && await _userManager.CheckPasswordAsync(user, query.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim("name", user.UserName = null!),
                    new Claim("email", user.Email = null!)
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim("role", userRole));
                }

            }

            throw new UnauthorizedAccessException();
        }
    }
}
