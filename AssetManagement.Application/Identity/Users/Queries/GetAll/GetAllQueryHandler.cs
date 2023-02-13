using AssetManagement.Application.Identity.Authentication.Common;
using AssetManagement.Application.Identity.Authentication.Queries.Login;
using AssetManagement.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Application.Identity.Users.Queries.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<User>>
    {
        private readonly UserManager<User> _userManager;

        public GetAllQueryHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<User>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.ToListAsync(); //TODO
            return users;
        }
    }
}
