﻿using AssetManagement.Application.Authentication.Common;
using AssetManagement.Application.Common.Interfaces.Authentication;
using AssetManagement.Application.Common.Interfaces.Persistence;
using AssetManagement.Domain.Entities;
using MediatR;

namespace AssetManagement.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                throw new Exception("User does not exist");
            }

            if (user.Password != query.Password)
            {
                throw new Exception("Invalid password");
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
