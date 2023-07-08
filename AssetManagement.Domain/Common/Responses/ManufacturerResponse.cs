

using AssetManagement.Domain.Entities;

namespace AssetManagement.Domain.Common.Responses;
public class ManufacturerResponse : BaseResponse<Manufacturer>
{
    public ManufacturerResponse(Manufacturer resource) : base(resource)
    {
    }

    public ManufacturerResponse(string message) : base(message)
    {
    }
}
