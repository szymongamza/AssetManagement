

using AssetManagement.Domain.Entities;

namespace AssetManagement.Domain.Common.Responses;
public class StocktakingResponse : BaseResponse<Stocktaking>
{
    public StocktakingResponse(Stocktaking resource) : base(resource)
    {
    }

    public StocktakingResponse(string message) : base(message)
    {
    }
}
