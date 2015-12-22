namespace BeiDream.Demo.Infrastructure.Repositories.DataPermissions
{
    /// <summary>
    /// 数据权限标识列表
    /// </summary>
    public static class PermissionCode
    {
        /// <summary>
        /// 只能查看自己创建的用户数据标识
        /// </summary>
        public const string LookSelfCreateUsers = "LookSelfCreateUsers";
        /// <summary>
        /// 只能查看自己修改的用户数据标识
        /// </summary>
        public const string LookSelfModifyUsers = "LookSelfModifyUsers";
    }
}