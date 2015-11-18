using System.Security.Principal;

namespace BeiDream.Core.Security
{
    /// <summary>
    /// 用户身份标识
    /// </summary>
    public class OwnIdentity: IIdentity 
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 认证类型
        /// </summary>
        public string AuthenticationType { get { return "ApplicationCookie"; } }

        /// <summary>
        /// 是否认证(登录)
        /// </summary>
        public bool IsAuthenticated { get; private set; }

        /// <summary>
        /// 应用程序上下文
        /// </summary>
        public  IApplicationSession ApplicationSession { get; private set; }

        public OwnIdentity( bool isAuthenticated, string name,IApplicationSession applicationSession)
        {
            IsAuthenticated = isAuthenticated;
            Name = name;
            ApplicationSession = applicationSession;
        }
    }
}