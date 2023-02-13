using AssetManagement.Application.Identity.Authentication.Commands.Register;
using AssetManagement.Application.Identity.Authentication.Common;
using AssetManagement.Application.Identity.Authentication.Queries.Login;
using AssetManagement.Contracts;
using AssetManagement.Domain.Entities;
using AutoMapper;

namespace AssetManagement.Api.Common.Mapping
{
    public class AuthenticationMappingProfile : Profile
    {
        public AuthenticationMappingProfile()
        {
            CreateMap<AuthenticationResult, AuthenticationResponse>()
                .ForMember(dest => dest.Token, act => act.MapFrom(src => src.Token))
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.UserName, act => act.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.User.Email));
            CreateMap<LoginRequest, LoginQuery>();
            CreateMap<RegisterRequest, RegisterCommand>();
        }
    }
}
