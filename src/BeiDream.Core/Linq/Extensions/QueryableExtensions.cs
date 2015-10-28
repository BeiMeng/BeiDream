using System.Linq;
using BeiDream.Utils.PagerHelper;
using System.Linq.Dynamic;
namespace BeiDream.Core.Linq.Extensions
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// 排序
        /// </summary>
        public static IQueryable<T> OrderByIfOrderNullOrEmpty<T>( this IQueryable<T> source, string order)
        {
            if (string.IsNullOrWhiteSpace(order))
                return source;
            return source.OrderBy(order);
        }
    }
}