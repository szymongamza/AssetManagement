
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);

    }
}
