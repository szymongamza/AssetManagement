using AssetManagement.Domain.Entities;

namespace AssetManagement.Domain.Common.Responses;

public class FacultyResponse : BaseResponse<Faculty>
{
    public FacultyResponse(Faculty resource) : base(resource)
    {
    }

    public FacultyResponse(string message) : base(message)
    {
    }
}