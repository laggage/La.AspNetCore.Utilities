using System.Collections.Generic;

namespace La.AspNetCore.Extensions.Paging
{
    public class PageModel<T> : PageModel
        where T : class
    {
        public List<T> Items { get; }

        public int ItemsCount => Items.Count;

        public PageModel(
            int pageIndex,
            int pageSize,
            int totalItemsCount,
            IEnumerable<T> items)
            : base(pageIndex, pageSize, totalItemsCount)
        {
            Items = new List<T>(items);
        }
    }
}
