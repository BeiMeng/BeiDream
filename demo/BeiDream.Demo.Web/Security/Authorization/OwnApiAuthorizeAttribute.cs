using BeiDream.Core.Security.Authorization;
using BeiDream.Demo.Infrastructure.Security.Authorization;
using BeiDream.Web.Api.Authorization;

namespace BeiDream.Demo.Web.Security.Authorization
{
    public class OwnApiAuthorizeAttribute:ApiAuthorizeAttributeBase
    {
        public OwnApiAuthorizeAttribute(string permission=null) : base(permission)
        {
        }

        protected override IPermissionManager CreatePermissionManager()
        {
            //传入的permission为null或"",则默认只进行身份认证，不进行授权验证,都能访问
            return new WebApiPermissionManager(new PermissionSupportService(), Permission, string.IsNullOrWhiteSpace(Permission));
        }
    }
}