using BeiDream.Utils.Logging;
using BeiDream.Web.Mvc.Web.Enum;
using System;
using System.Web;
using System.Web.Mvc;
using BeiDream.Utils.Extensions;

namespace BeiDream.Web.Mvc.Filter
{
    /// <summary>
    /// 全局异常过滤器
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class ExceptionHandlerAttribute : HandleErrorAttribute
    {
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(ExceptionHandlerAttribute));

        /// <summary>
        /// 处理异常
        /// </summary>
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Logger.Error(filterContext.Exception);
            filterContext.ExceptionHandled = true;
            filterContext.Result = IsAjaxRequest(filterContext)
            ? GenerateAjaxResult(filterContext)
            : GenerateNonAjaxResult(filterContext);
        }

        private bool IsAjaxRequest(ExceptionContext filterContext)
        {
            return filterContext.HttpContext.Request.IsAjaxRequest();
        }

        private ActionResult GenerateAjaxResult(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.StatusCode = 200;
            return new AjaxResponse(StateCode.Fail, filterContext.Exception.Message).GetJsonResult();
        }

        private ActionResult GenerateNonAjaxResult(ExceptionContext filterContext)
        {
            filterContext.CheckNotNull("filterContext");
            string controllerName = (string)filterContext.RouteData.Values["controller"];
            string actionName = (string)filterContext.RouteData.Values["action"];
            HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
            var result = new ViewResult
            {
                ViewName = this.View,
                MasterName = this.Master,
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                TempData = filterContext.Controller.TempData
            };
            filterContext.Result = result;
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            return result;
        }
         
    }
}