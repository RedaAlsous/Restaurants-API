using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Common;

public class PagedResult<T>
{
    public PagedResult(IEnumerable<T> items, int totalCount, int pageSize, int PageNumber)
    {
        Items = items;
        TotlaItemsCount = totalCount;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        ItemsFrom = pageSize * (PageNumber - 1) + 1;
        ItemsTo = ItemsFrom + pageSize - 1;
    }
    public IEnumerable<T> Items { get; set; }
    public int TotalPages { get; set; }

    public int TotlaItemsCount { get; set; }

    public int ItemsFrom { get; set; }
    public int ItemsTo { get; set; }
}
