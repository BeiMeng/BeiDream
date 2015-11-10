using BeiDream.Utils.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeiDream.Utils
{
    public class ConvertHelper
    {
        /// <summary>
        /// 转换为目标元素
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="data">数据</param>
        public static T To<T>(object data)
        {
            if (data == null)
                return default(T);
            if (data is string && string.IsNullOrWhiteSpace(data.ToString()))
                return default(T);
            Type type = TypeHelper.GetType<T>();
            try
            {
                if (type.Name.ToLower() == "guid")
                    return (T)(object)new Guid(data.ToString());
                if (data is IConvertible)
                    return (T)Convert.ChangeType(data, type);
                return (T)data;
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// 转换为目标元素集合
        /// </summary>
        /// <typeparam name="T">目标元素类型</typeparam>
        /// <param name="list">元素集合字符串，范例:83B0233C-A24F-49FD-8083-1337209EBC9A,EAB523C6-2FE7-47BE-89D5-C6D440C3033A</param>
        public static List<T> ToList<T>(string list)
        {
            var result = new List<T>();
            if (string.IsNullOrWhiteSpace(list))
                return result;
            var array = list.Split(',');
            result.AddRange(from each in array where !string.IsNullOrWhiteSpace(each) select To<T>(each));
            return result;
        }
    }
}