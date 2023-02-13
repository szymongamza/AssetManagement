using AssetManagement.Application.Identity.Authentication.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Identity.Authentication.Queries.Login
{
    public record LoginQuery : IRequest<AuthenticationResult>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
