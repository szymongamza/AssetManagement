﻿

namespace AssetManagement.Domain.Common.Query;
public class Query
{
    public int Page { get; set; }
    public int ItemsPerPage { get; set; }

    public Query(int page, int itemsPerPage)
    {
        Page = page;
        ItemsPerPage = itemsPerPage;

        if (Page <= 0)
            Page = 1;

        if (ItemsPerPage <= 0)
            ItemsPerPage = 10;

    }
}
