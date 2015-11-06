using System;

namespace BeiDream.Utils.Reflection
{
    /// <summary>
    /// Some simple type-checking methods used internally.
    /// </summary>
    public static class TypeHelper
    {
        public static bool IsFunc(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var type = obj.GetType();
            if (!type.IsGenericType)
            {
                return false;
            }

            return type.GetGenericTypeDefinition() == typeof(Func<>);
        }

        public static bool IsFunc<TReturn>(object obj)
        {
            return obj != null && obj.GetType() == typeof(Func<TReturn>);
        }

        public static bool IsPrimitiveExtendedIncludingNullable(Type type)
        {
            if (IsPrimitiveExtended(type))
            {
                return true;
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return IsPrimitiveExtended(type.GenericTypeArguments[0]);
            }

            return false;
        }
        /// <summary>
        /// 获取类型,对可空类型进行处理
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        public static Type GetType<T>()
        {
            return Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
        }
        private static bool IsPrimitiveExtended(Type type)
        {
            if (type.IsPrimitive)
            {
                return true;
            }

            return type == typeof (string) ||
                   type == typeof (decimal) ||
                   type == typeof (DateTime) ||
                   type == typeof (DateTimeOffset) ||
                   type == typeof (TimeSpan) ||
                   type == typeof (Guid);
        }
    }
}
