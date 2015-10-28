namespace BeiDream.Utils.PagerHelper
{
    /// <summary>
    /// 分页接口
    /// </summary>
    public interface IPager
    {
        /// <summary>
        /// 页数，即第几页，从1开始
        /// </summary>
        int Page { get; set; }
        /// <summary>
        /// 每页显示行数
        /// </summary>
        int PageSize { get; set; }
        /// <summary>
        /// 总行数
        /// </summary>
        int TotalCount { get; set; }
        /// <summary>
        /// 排序条件
        /// </summary>
        string Order { get; set; }
        /// <summary>
        /// 获取总页数
        /// </summary>
        int GetPageCount();
        /// <summary>
        /// 获取跳过的行数
        /// </summary>
        int GetSkipCount();
    }
}