using System;

namespace BeiDream.Core.Security.Authorization
{
    /// <summary>
    /// 权限
    /// </summary>
    public class Permission
    {
        /// <summary>
        /// 初始化权限
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <param name="isDeny">是否拒绝</param>
        public Permission(string roleId, bool isDeny)
        {
            RoleId = Filter(roleId);
            Validate(RoleId);
            IsDeny = isDeny;
        }

        /// <summary>
        /// 验证角色编号
        /// </summary>
        private void Validate(string roleId)
        {
            if (string.IsNullOrWhiteSpace(roleId))
                throw new ArgumentNullException("roleId");
        }

        /// <summary>
        /// 角色编号
        /// </summary>
        public string RoleId { get; private set; }

        /// <summary>
        /// 是否拒绝
        /// </summary>
        public bool IsDeny { get; private set; }

        /// <summary>
        /// 验证是否具有资源访问权限
        /// </summary>
        /// <param name="roleId">角色编号</param>
        public bool? HasPermission(string roleId)
        {
            roleId = Filter(roleId);
            Validate(roleId);
            if (roleId != RoleId)
                return null;
            if (IsDeny)
                return false;
            return true;
        }

        /// <summary>
        /// 过滤参数
        /// </summary>
        private string Filter(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;
            return text.Trim().ToLower();
        }
    }
}