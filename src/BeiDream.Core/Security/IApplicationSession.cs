namespace BeiDream.Core.Security
{
    /// <summary>
    /// 当前会话用户的应用程序上下文
    /// </summary>
    public interface IApplicationSession
    {
        /// <summary>
        /// 是否认证(登录)
        /// </summary>
        bool IsAuthenticated { get; }
        /// <summary>
        /// 用户唯一编号
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 角色编号列表
        /// </summary>
        string[] RoleIds { get; }
    }
}