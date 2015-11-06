using System.Collections.Generic;
using System.Web.Mvc;
using BeiDream.Core.Json;
using BeiDream.Utils.Extensions;
using BeiDream.Web.Mvc.Web.Enum;

namespace BeiDream.Web.Mvc
{
    /// <summary>
    /// ajax请求返回结果对象
    /// </summary>
    public class AjaxResponse
    {
        /// <summary>
        /// 初始化Mvc返回结果
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="message">消息</param>
        /// <param name="data">数据</param>
        public AjaxResponse(StateCode code, string message, IEnumerable<object> data = null)
        {
            _code = code;
            _message = message;
            _data = data;
        }

        /// <summary>
        /// 状态码
        /// </summary>
        private readonly StateCode _code;
        /// <summary>
        /// 消息
        /// </summary>
        private readonly string _message;
        /// <summary>
        /// 数据
        /// </summary>
        private readonly IEnumerable<object> _data;
        /// <summary>
        /// 获取输出结果
        /// </summary>
        public ActionResult GetJsonResult()
        {
            return new ContentResult { Content = new { Code = _code.Value(), Message = _message, Data = _data }.ToJsonString() };
        }
    }
}