using System;
using System.Web.Mvc;
using BeiDream.Utils.Logging;
using BeiDream.Web.Mvc.Web.Enum;

namespace BeiDream.Web.Mvc.Filter
{   
    /// <summary>
    /// 全局异常过滤器
    /// </summary>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true )]
    public class ExceptionHandlerAttribute: HandleErrorAttribute
    {
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(ExceptionHandlerAttribute));
        /// <summary>
        /// 处理异常
        /// </summary>
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            Logger.Error(context.Exception);
            context.ExceptionHandled = true;
            context.Result = IsAjaxRequest(context)
            ? GenerateAjaxResult(context)
            : GenerateNonAjaxResult(context);
        }
        private bool IsAjaxRequest(ExceptionContext context)
        {
            return context.HttpContext.Request.IsAjaxRequest();
        }
        private ActionResult GenerateAjaxResult(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 200;
            return new AjaxResponse(StateCode.Fail, context.Exception.Message).GetJsonResult();
        }
        private ActionResult GenerateNonAjaxResult(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 500;
            return new ViewResult
            {
                ViewName = View,
                MasterName = Master,
                ViewData = new ViewDataDictionary(new {context.Exception}),
                TempData = context.Controller.TempData
            };
        }
    }
}