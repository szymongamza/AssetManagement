using AssetManagement.Domain.Entities;

namespace AssetManagement.Domain.Common.Responses;

public class DepartmentResponse : BaseResponse<Department>
{
    public DepartmentResponse(Department resource) : base(resource)
    {
    }

    public DepartmentResponse(string message) : base(message)
    {
    }
}
