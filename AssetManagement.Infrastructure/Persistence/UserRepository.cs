﻿
using AssetManagement.Application.Common.Interfaces.Persistence;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();
        public User? GetUserByEmail(string email)
        {
           return _users.SingleOrDefault(u => u.Email == email);
        }

        public void Add(User user)
        {
            _users.Add(user);
        }
    }
}
