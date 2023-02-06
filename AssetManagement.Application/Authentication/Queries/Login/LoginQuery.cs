using AssetManagement.Application.Authentication.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Authentication.Queries.Login
{
    public record LoginQuery : IRequest<AuthenticationResult>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
