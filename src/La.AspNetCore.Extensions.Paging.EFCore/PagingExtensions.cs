// ReSharper disable once CheckNamespace

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace La.AspNetCore.Extensions.Paging
{
    public static class PagingExtensions
    {
        public static Task<PageModel<T>> PageAsync<T>(
            this IQueryable<T> source,
            int pageIndex)
            where T : class
        {
            return source.PageAsync(pageIndex, PageModel.DefaultPageSize);
        }
        
        public static async Task<PageModel<T>> PageAsync<T>(
            this IQueryable<T> source,
            int pageIndex,
            int pageSize)
            where T : class
        {
            source = source ?? throw new ArgumentNullException(nameof(source));
            int totalItemsCount = await source.CountAsync();
            var data = await source.Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return new PageModel<T>(
                pageIndex, pageSize, totalItemsCount, data);
        }

        public static Task<PageModel<T>> PageAsync<T>(
            this IQueryable<T> source,
            PaginationQueryParams queryParams)
            where T : class
        {
            return source.PageAsync(queryParams.PageIndex, queryParams.PageSize);
        }
    }
}