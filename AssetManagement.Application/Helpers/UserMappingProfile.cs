

using AssetManagement.Application.Resources.User;
using AssetManagement.Application.Resources;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AutoMapper;

namespace AssetManagement.Application.Helpers;
public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserResource>();
        CreateMap<QueryResult<User>, QueryResultResource<UserResource>>();
        CreateMap<UserQueryResource, UserQuery>();
        CreateMap<SaveUserResource, User>()
            .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(x => x.LastModifiedUtc, opt => opt.Ignore())
            .ForMember(x => x.CreatedUtc, opt => opt.Ignore())
            .ForMember(x => x.Assets, opt => opt.Ignore());
    }
}
