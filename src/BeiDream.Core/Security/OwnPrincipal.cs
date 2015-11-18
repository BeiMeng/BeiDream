using System.Security.Principal;

namespace BeiDream.Core.Security
{
    /// <summary>
    /// 安全主体
    /// </summary>
    public class OwnPrincipal : IPrincipal
    {
        /// <summary>
        /// 身份标识
        /// </summary>
        public IIdentity Identity { get; private set; }

        public OwnPrincipal(IIdentity identity)
        {
            Identity = identity;
        }

        /// <summary>
        /// 获取身份标识
        /// </summary>
        public OwnIdentity GetIdentity()
        {
            return Identity as OwnIdentity;
        }






        public bool IsInRole(string role)
        {
            throw new System.NotImplementedException();
        }
    }
}