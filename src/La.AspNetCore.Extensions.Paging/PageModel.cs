namespace La.AspNetCore.Extensions.Paging
{
    public class PageModel
    {
        public const int DefaultPageSize = 12;

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalItemsCount { get; set; }

        public int PageCount => (TotalItemsCount / PageSize) + (TotalItemsCount % PageSize > 0 ? 1 : 0);

        public bool HasPrevious => PageIndex > 1;

        public bool HasNext => PageIndex + 1 <= PageCount;

        public PageModel(int pageIndex, int pageSize, int totalItemsCount)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalItemsCount = totalItemsCount;
        }

        public PageModel()
            : this(1, DefaultPageSize, 0)
        {
        }
    }
}
