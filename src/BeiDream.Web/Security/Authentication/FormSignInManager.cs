using System.Web.Security;
using BeiDream.Core.Security.Authentication;

namespace BeiDream.Web.Security.Authentication
{
    /// <summary>
    /// Form认证
    /// </summary>
    public class FormSignInManager : ISignInManager
    {
        public void SignIn(string name, bool isPersistent = false)
        {
            FormsAuthentication.SetAuthCookie(name, isPersistent);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}