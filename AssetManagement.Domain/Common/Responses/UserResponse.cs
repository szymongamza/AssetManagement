
using AssetManagement.Domain.Entities;

namespace AssetManagement.Domain.Common.Responses;
public class UserResponse : BaseResponse<User>
{
    public UserResponse(User resource) : base(resource)
    {
    }

    public UserResponse(string message) : base(message)
    {
    }
}
