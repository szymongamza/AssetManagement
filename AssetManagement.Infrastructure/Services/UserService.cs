
using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Application.Interfaces.Services;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Common.Responses;
using AssetManagement.Domain.Entities;
using AssetManagement.Domain.Enums;
using Microsoft.Extensions.Caching.Memory;

namespace AssetManagement.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMemoryCache _memoryCache;

    public UserService(IUserRepository userRepository, IMemoryCache memoryCache)
    {
        _userRepository = userRepository;
        _memoryCache = memoryCache;
    }
    public async Task<QueryResult<User>> ListAsync(UserQuery query, CancellationToken token)
    {
        string cacheKey = GetCacheKeyForUserQuery(query);

        var users = await _memoryCache.GetOrCreateAsync(cacheKey, (entry) =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);
            return  _userRepository.ToListAsync(query, token);
        });

        return users;
    }
    public async Task<UserResponse> AddAsync(User user, CancellationToken token)
    {
        try
        {
            await _userRepository.AddAsync(user, token);

            return new UserResponse(user);
        }
        catch (Exception ex)
        {
            return new UserResponse($"An error occurred when adding the user: {ex.Message}");
        }
    }

    public async Task<UserResponse> UpdateAsync(int id, User user, CancellationToken token)
    {
        var existingUser = await _userRepository.FindByIdAsync(id, token);

        if (existingUser == null)
        {
            return new UserResponse("User not found");
        }

        existingUser.PhoneNumber = user.PhoneNumber;
        existingUser.Name = user.Name;
        existingUser.Email = user.Email;

        try
        {
            await _userRepository.UpdateAsync(existingUser, token);
            return new UserResponse(existingUser);
        }
        catch (Exception ex)
        {
            return new UserResponse($"An error occurred when updating the user: {ex.Message}");
        }
    }

    public async Task<UserResponse> DeleteAsync(int id, CancellationToken token)
    {
        var existingUser = await _userRepository.FindByIdAsync(id, token);

        if (existingUser == null)
        {
            return new UserResponse("User not found");
        }

        try
        {
            await _userRepository.DeleteAsync(existingUser, token);
            return new UserResponse(existingUser);
        }
        catch (Exception ex)
        {
            return new UserResponse($"An error occurred when deleting the user: {ex.Message}");
        }
    }
    private static string GetCacheKeyForUserQuery(UserQuery query)
    {
        string key = CacheKeys.UserList.ToString();
        key = string.Concat(key, "_", query.Page, "_", query.ItemsPerPage);
        return key;
    }
}
