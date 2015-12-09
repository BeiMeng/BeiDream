using System.Security.Principal;
using System.Web;

namespace BeiDream.Core.Security
{
    /// <summary>
    /// 当前会话用户的应用程序上下文
    /// </summary>
    public class ApplicationSession : IApplicationSession
    {
        public ApplicationSession(bool isAuthenticated, string name)
        {
            IsAuthenticated = isAuthenticated;
            Name = name;
        }

        /// <summary>
        /// 是否认证(登录)
        /// </summary>
        public bool IsAuthenticated { get; private set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 角色编号列表
        /// </summary>
        public string[] RoleIds { get; set; }
        /// <summary>
        /// 是否超级管理员
        /// </summary>
        public bool IsAdmin { get; set; }
        /// <summary>
        /// 当前用户安全主体
        /// </summary>
        public static OwnPrincipal User
        {
            get
            {
                IPrincipal principal = HttpContext.Current == null ? System.Threading.Thread.CurrentPrincipal : HttpContext.Current.User;
                return principal as OwnPrincipal ?? new OwnPrincipal(new OwnIdentity(false,"",null));
            }
            set
            {
                if (HttpContext.Current == null)
                {
                    System.Threading.Thread.CurrentPrincipal = value;
                    return;
                }
                HttpContext.Current.User = value;
            }
        }
        /// <summary>
        /// 当前用户身份标识
        /// </summary>
        public static OwnIdentity Identity
        {
            get { return User.GetIdentity(); }
        }
        /// <summary>
        /// 获取当前应用程序上下文
        /// </summary>
        public static IApplicationSession Current
        {
            get { return Identity.ApplicationSession; }
        }
    }
}