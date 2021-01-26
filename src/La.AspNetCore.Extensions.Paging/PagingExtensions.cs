using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace La.AspNetCore.Extensions.Paging
{
    public static class PagingExtensions
    {
        /// <summary>
        /// 使用 <see cref="PageModel.DefaultPageSize"/> 定义的默认页尺寸对数据源进行分页
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalItemsCount">default to null, set to null will use source.Count()</param>
        /// <returns> <see cref="PageModel{T}"/> </returns>
        public static PageModel<T> Page<T>(
            this IEnumerable<T> source,
            int pageIndex,
            int? totalItemsCount = null)
            where T : class
        {
            return source.Page(pageIndex, PageModel.DefaultPageSize, totalItemsCount);
        }

        /// <summary>
        /// 对数据源进行分页
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="totalItemsCount">default to null, set to null will use source.Count()</param>
        /// <returns> <see cref="PageModel{T}"/> </returns>
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static PageModel<T> Page<T>(
            this IEnumerable<T> source,
            int pageIndex,
            int pageSize,
            int? totalItemsCount = null)
            where T : class
        {
            source = source ?? throw new ArgumentNullException(nameof(source));
            totalItemsCount ??= source.Count();
            var data = source.Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return new PageModel<T>(
                pageIndex, pageSize, totalItemsCount.Value, data);
        }

        public static PageModel<T> Page<T>(
            this IEnumerable<T> source,
            PaginationQueryParams queryParams)
            where T : class
        {
            return source.Page(queryParams.PageIndex, queryParams.PageSize);
        }
    }
}
