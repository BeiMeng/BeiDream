using BeiDream.Utils.PagerHelper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BeiDream.Web.Mvc.EasyUi
{
    public class EasyUiControllerBase : OwnControllerBase
    {
        /// <summary>
        /// 转换为DataGrid输出结果
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="data">实体列表</param>
        /// <param name="totalCount">总行数</param>
        protected ActionResult ToDataGridResult<T>(IList<T> data, int totalCount = 0)
        {
            return ToJsonResult(new { total = totalCount, rows = data });
        }

        #region 分页设置

        /// <summary>
        /// 设置分页
        /// </summary>
        /// <param name="query">查询实体</param>
        protected void SetPage(IPager query)
        {
            query.Page = GetPageIndex();
            query.PageSize = GetPageSize();
            query.Order = GetOrder();
        }

        /// <summary>
        /// 获取分页的页索引
        /// </summary>
        protected int GetPageIndex()
        {
            var page = Convert.ToInt32(Request["page"]);
            return page > 0 ? page : 1;
        }

        /// <summary>
        /// 获取分页大小
        /// </summary>
        protected int GetPageSize()
        {
            var pageSize = Convert.ToInt32(Request["rows"]);
            return pageSize > 0 ? pageSize : 20;
        }

        /// <summary>
        /// 获取排序
        /// </summary>
        protected string GetOrder()
        {
            return string.Format("{0} {1}", Convert.ToString(Request["sort"]), Convert.ToString(Request["order"]));
        }

        #endregion 分页设置
    }
}