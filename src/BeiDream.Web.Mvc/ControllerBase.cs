using System.Collections.Generic;
using System.Web.Mvc;
using BeiDream.Core.Json;
using BeiDream.Web.Mvc.Web.Enum;

namespace BeiDream.Web.Mvc
{
    public class ControllerBase : Controller
    {
        /// <summary>
        /// 转换为Json结果
        /// </summary>
        /// <param name="data">对象</param>
        public ActionResult ToJsonResult(object data)
        {
            return Content(data.ToJsonString());
        }
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="data">数据</param>
        protected virtual ActionResult AjaxOkResponse(string message = "操作成功", IEnumerable<object> data = null)
        {
            return new AjaxResponse(StateCode.Ok, message, data).GetJsonResult();
        }
    }
}