using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace La.AspNetCore.Extensions.Paging
{
    public static class PagingExtensions
    {
        /// <summary>
        /// 使用 <see cref="PageModel.DefaultPageSize"/> 定义的默认页尺寸对数据源进行分页
        /// 如果数据源是延迟加载的集合类型, 那么请考虑使用 <see cref="PageAsync{T}(IEnumerable{T}, int)"/>
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="pageIndex">页码</param>
        /// <returns> <see cref="PageModel{T}"/> </returns>
        public static PageModel<T> Page<T>(
            this IEnumerable<T> source,
            int pageIndex)
            where T : class
        {
            return source.Page(pageIndex, PageModel.DefaultPageSize);
        }

        /// <summary>
        /// 对数据源进行分页, 如果数据源是延迟加载的集合类型, 那么请考虑使用 <see cref="PageAsync{T}(IEnumerable{T}, int, int)"/>
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页尺寸</param>
        /// <returns> <see cref="PageModel{T}"/> </returns>
        public static PageModel<T> Page<T>(
            this IEnumerable<T> source,
            int pageIndex,
            int pageSize)
            where T : class
        {
            int totalItemsCount = source.Count();
            var data = source.Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return new PageModel<T>(
                pageIndex, pageSize, totalItemsCount, data);
        }

        /// <summary>
        /// 对数据源进行分页, 如果数据源不是延迟的加载的集合, 请勿使用此异步方法
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页尺寸</param>
        /// <returns> <see cref="PageModel{T}"/> </returns>
        public static Task<PageModel<T>> PageAsync<T>(
            this IEnumerable<T> source,
            int pageIndex,
            int pageSize)
            where T : class
        {
            return Task.Run(() => source.Page(pageIndex, pageSize));
        }

        /// <summary>
        /// 使用 <see cref="PageModel.DefaultPageSize"/> 定义的默认页尺寸对数据源进行分页, 如果数据源不是延迟的加载的集合, 请勿使用此异步方法
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="pageIndex">页码</param>
        /// <returns> <see cref="PageModel{T}"/> </returns>
        public static Task<PageModel<T>> PageAsync<T>(
            this IEnumerable<T> source,
            int pageIndex)
            where T : class
        {
            return Task.Run(() => source.Page(pageIndex));
        }
    }
}
