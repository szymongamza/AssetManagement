

using AssetManagement.Domain.Entities;

namespace AssetManagement.Domain.Common.Responses;
public class AssetResponse : BaseResponse<Asset>
{
    public AssetResponse(Asset resource) : base(resource)
    {
    }

    public AssetResponse(string message) : base(message)
    {
    }
}
