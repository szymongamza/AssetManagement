﻿using AssetManagement.Domain.Entities;
using AutoMapper;

namespace AssetManagement.Api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //
            // CreateMap<AuthenticationResult, AuthenticationResponse>()
            //     .ForMember(dest => dest.Token, act => act.MapFrom(src => src.Token))
            //     .ForMember(dest => dest.Id, act => act.MapFrom(src => src.User.Id))
            //     .ForMember(dest => dest.UserName, act => act.MapFrom(src => src.User.UserName))
            //     .ForMember(dest => dest.Email, act => act.MapFrom(src => src.User.Email));
            // CreateMap<RegisterResult, RegisterResponse>()
            //     .ForMember(dest => dest.Id, act => act.MapFrom(src => src.User.Id))
            //     .ForMember(dest => dest.UserName, act => act.MapFrom(src => src.User.UserName))
            //     .ForMember(dest => dest.Email, act => act.MapFrom(src => src.User.Email));
            // CreateMap<LoginRequest, LoginQuery>();
            // CreateMap<RegisterRequest, RegisterCommand>();
        }
    }
}