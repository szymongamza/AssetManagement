using AssetManagement.Domain.Entities.Identity;
using MediatR;
using AssetManagement.Application.Common.Interfaces.Authentication;

namespace AssetManagement.Application.Identity.Users.Queries.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<User>>
    {
        private readonly IIdentityService _identityService;

        public GetAllQueryHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<List<User>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var users = await _identityService.GetAllUsersAsync(cancellationToken);
            return users;
        }
    }
}
