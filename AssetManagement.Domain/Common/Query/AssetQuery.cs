

namespace AssetManagement.Domain.Common.Query;
public class AssetQuery : Query
{
    public Guid? QRCode { get; set; }
    public AssetQuery(int page, int itemsPerPage, Guid? qRCode) : base(page, itemsPerPage)
    {
        QRCode = qRCode;
    }
}
