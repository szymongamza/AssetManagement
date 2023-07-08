using AssetManagement.Domain.Entities;

namespace AssetManagement.Domain.Common.Responses; 
public class BuildingResponse : BaseResponse<Building>
{
    public BuildingResponse(Building resource) : base(resource)
    {
    }

    public BuildingResponse(string message) : base(message)
    {
    }
}
