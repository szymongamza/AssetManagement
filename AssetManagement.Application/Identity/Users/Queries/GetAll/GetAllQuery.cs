using AssetManagement.Application.Identity.Authentication.Common;
using AssetManagement.Domain.Entities.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Identity.Users.Queries.GetAll
{
    public record GetAllQuery : IRequest<List<User>>
    {
    }
}
