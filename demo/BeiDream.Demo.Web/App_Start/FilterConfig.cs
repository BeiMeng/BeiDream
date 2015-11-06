using System.Web;
using System.Web.Mvc;
using BeiDream.Web.Mvc.Filter;

namespace BeiDream.Demo.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionHandlerAttribute());
        }
    }
}
