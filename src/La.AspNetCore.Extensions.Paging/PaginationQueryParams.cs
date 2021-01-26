namespace La.AspNetCore.Extensions.Paging
{
    public class PaginationQueryParams
    {
        public PaginationQueryParams(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public PaginationQueryParams() : this(1, PageModel.DefaultPageSize)
        {
        }

        public virtual int PageIndex { get; init; }
        public virtual int PageSize { get; init; }
    }
}