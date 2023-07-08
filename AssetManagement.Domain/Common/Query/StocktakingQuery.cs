

namespace AssetManagement.Domain.Common.Query;
public class StocktakingQuery : Query
{
    public bool IsClosed { get; set; }
    public StocktakingQuery(bool isClosed, int page, int itemsPerPage) : base(page, itemsPerPage)
    {
        IsClosed = isClosed;
    }
}
