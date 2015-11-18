namespace BeiDream.Core.Security.Authentication
{
    public interface ISignInManager
    {
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="name">用户唯一编号</param>
        /// <param name="isPersistent"></param>
        void SignIn(string name, bool isPersistent = false);
        /// <summary>
        /// 登出
        /// </summary>
        void SignOut();
    }
}