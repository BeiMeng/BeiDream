using System;

namespace BeiDream.Utils.Extensions
{
    /// <summary>
    /// 枚举扩展
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// 获取成员值
        /// </summary>
        /// <param name="instance">枚举实例</param>
        public static int Value(this Enum instance)
        {
            return GetValue(instance.GetType(), instance);
        }
        /// <summary>
        /// 获取成员值
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="member">成员名、值、实例均可</param>
        public static int GetValue(Type type, object member)
        {
            string value = member == null ? string.Empty : member.ToString().Trim();
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("member");
            return (int)Enum.Parse(type, value, true);
        }
    }
}