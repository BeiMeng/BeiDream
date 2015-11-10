using System;
using System.Collections.Generic;
using System.Linq;

namespace BeiDream.Utils.PagerHelper
{
    /// <summary>
    /// 分页集合
    /// </summary>
    /// <typeparam name="T">元素类型</typeparam>
    public class PagerList<T> : List<T>
    {
        /// <summary>
        /// 分页集合
        /// </summary>
        /// <param name="pager">查询对象</param>
        public PagerList(IPager pager)
            : this(pager.Page, pager.PageSize, pager.TotalCount, pager.Order)
        {
        }

        /// <summary>
        /// 分页集合
        /// </summary>
        /// <param name="totalCount">总行数</param>
        public PagerList(int totalCount)
            : this(1, 20, totalCount)
        {
        }

        /// <summary>
        /// 分页集合
        /// </summary>
        /// <param name="page">页索引</param>
        /// <param name="pageSize">每页显示行数</param>
        /// <param name="totalCount">总行数</param>
        public PagerList(int page, int pageSize, int totalCount)
            : this(page, pageSize, totalCount, "")
        {
        }

        /// <summary>
        /// 分页集合
        /// </summary>
        /// <param name="page">页索引</param>
        /// <param name="pageSize">每页显示行数</param>
        /// <param name="totalCount">总行数</param>
        /// <param name="order">排序条件</param>
        public PagerList(int page, int pageSize, int totalCount, string order)
        {
            var pager = new Pager(page, pageSize, totalCount);
            TotalCount = pager.TotalCount;
            PageCount = pager.GetPageCount();
            Page = pager.Page;
            PageSize = pager.PageSize;
            Order = order;
        }

        /// <summary>
        /// 页索引，即第几页，从1开始
        /// </summary>
        public int Page { get; private set; }

        /// <summary>
        /// 每页显示行数
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// 总行数
        /// </summary>
        public int TotalCount { get; private set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; private set; }

        /// <summary>
        /// 排序条件
        /// </summary>
        public string Order { get; private set; }

        /// <summary>
        /// 转换分页集合的元素类型
        /// </summary>
        /// <typeparam name="TResult">目标元素类型</typeparam>
        /// <param name="converter">转换方法</param>
        public PagerList<TResult> Convert<TResult>(Func<T, TResult> converter)
        {
            var result = new PagerList<TResult>(Page, PageSize, TotalCount, Order);
            result.AddRange(this.Select(converter));
            return result;
        }
    }
}