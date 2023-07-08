

namespace AssetManagement.Domain.Common.Query;
public class UserQuery : Query
{
    public UserQuery(int page, int itemsPerPage) : base(page, itemsPerPage)
    {
    }
}
