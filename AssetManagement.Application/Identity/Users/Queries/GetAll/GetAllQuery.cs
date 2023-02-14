using AssetManagement.Domain.Entities.Identity;
using MediatR;


namespace AssetManagement.Application.Identity.Users.Queries.GetAll
{
    public record GetAllQuery : IRequest<List<User>>
    {
    }
}
