namespace BeiDream.Utils.PagerHelper
{
    public class Pager : IPager
    {
        /// <summary>
        /// 初始化分页
        /// </summary>
        public Pager()
            : this(1)
        {
        }

        /// <summary>
        /// 初始化分页
        /// </summary>
        /// <param name="page">页索引</param>
        /// <param name="pageSize">每页显示行数,默认20</param>
        /// <param name="order">排序条件</param>
        public Pager(int page, int pageSize, string order)
            : this(page, pageSize, 0, order)
        {
        }

        /// <summary>
        /// 初始化分页
        /// </summary>
        /// <param name="page">页索引</param>
        /// <param name="pageSize">每页显示行数,默认20</param>
        /// <param name="totalCount">总行数</param>
        /// <param name="order">排序条件</param>
        public Pager(int page, int pageSize = 20, int totalCount = 0, string order = "")
        {
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
            Order = order;
        }

        private int _pageIndex;

        /// <summary>
        /// 页索引，即第几页，从1开始
        /// </summary>
        public int Page
        {
            get
            {
                if (_pageIndex <= 0)
                    _pageIndex = 1;
                return _pageIndex;
            }
            set { _pageIndex = value; }
        }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public string Order { get; set; }

        public int GetPageCount()
        {
            if (TotalCount == 0)
                return 0;
            if ((TotalCount % PageSize) == 0)
                return TotalCount / PageSize;
            return (TotalCount / PageSize) + 1;
        }

        /// <summary>
        /// 获取跳过的行数，分页查询使用
        /// </summary>
        /// <returns></returns>
        public int GetSkipCount()
        {
            if (Page > GetPageCount())
                Page = GetPageCount();
            return PageSize * (Page - 1);
        }
    }
}