using System.Reflection;
using System.Security;
using System.Web;
using BeiDream.Core.Security.Authorization;
using BeiDream.Demo.Infrastructure.Security.Authorization;
using BeiDream.Demo.Web.Security.Authorization;

namespace BeiDream.Demo.Web.Areas.Systems.Models
{
    public class VmPermission
    {
        /// <summary>
        /// 根据Url判断当前用户是具有授权
        /// </summary>
        /// <param name="requestUrl">请求Url</param>
        public  bool HasPermission(string requestUrl)
        {
            var permissionManager = new WebPermissionManager(new PermissionSupportService(),
                false);
            if (permissionManager.HasPermission(requestUrl))
                return true;
            return false;
        }
    }
}