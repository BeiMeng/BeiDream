using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using BeiDream.Core.Security.Authentication;
using BeiDream.Utils.Extensions;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace BeiDream.Web.Security.Authentication
{
    public class IdentitySignInManager : ISignInManager
    {
        /// <summary>
        ///  基于Asp.Net Identity的登入
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isPersistent"></param>
        public void SignIn(string name, bool isPersistent = false)
        {
            var identity = CreateClaimsIdentity(name);
            var authenticationManager = GetAuthenticationManager();
            authenticationManager.SignOut("ApplicationCookie");
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        /// <summary>
        /// 创建声明标识
        /// </summary>
        private  ClaimsIdentity CreateClaimsIdentity(string name)
        {
            //默认ClaimsIdentity的IsAutheiticated是false，只有当我们构造函数中指定Authentication Type，它才为true
            ClaimsIdentity identity = new ClaimsIdentity("ApplicationCookie");
            //identity.AddClaim(new Claim(ClaimTypes.Role, "R1"));
            identity.AddClaim(new Claim(ClaimTypes.Name, name));
            //identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"));
            return identity;
        }

        /// <summary>
        /// 获取授权管理器
        /// </summary>
        private  IAuthenticationManager GetAuthenticationManager()
        {
            var owinContext = GetOwinContext();
            IAuthenticationManager authenticationManager = owinContext.Authentication;
            authenticationManager.CheckNotNull("authenticationManager");
            return authenticationManager;
        }

        /// <summary>
        /// 获取OWin上下文
        /// </summary>
        private  IOwinContext GetOwinContext()
        {
            var owinEnvironment = (IDictionary<string, object>)HttpContext.Current.Items["owin.Environment"];
            owinEnvironment.CheckNotNull("owinEnvironment");
            return new OwinContext(owinEnvironment);
        }

        /// <summary>
        /// 基于Asp.Net Identity的退出
        /// </summary>
        public  void SignOut()
        {
            var authenticationManager = GetAuthenticationManager();
            authenticationManager.SignOut("ApplicationCookie");
        }
    }
}