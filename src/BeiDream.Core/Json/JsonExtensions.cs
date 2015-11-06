using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BeiDream.Core.Json
{
    /// <summary>
    /// json转换扩展
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// 将Json字符串转换为对象
        /// </summary>
        /// <param name="json">Json字符串</param>
        public static T ToObject<T>(this string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return default(T);
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 将对象转换为Json字符串
        /// </summary>
        /// <param name="target">目标对象</param>
        /// <param name="camelCase">是否驼峰命名</param>
        /// <param name="indented">是否缩排</param>
        /// <param name="isConvertSingleQuotes">是否将双引号转成单引号</param>
        public static string ToJsonString(this object target, bool camelCase = false, bool indented = false, bool isConvertSingleQuotes = false)
        {
            var options = new JsonSerializerSettings();

            if (camelCase)
            {
                options.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }

            if (indented)
            {
                options.Formatting = Formatting.Indented;
            }
            if (target == null)
                return "{}";
            var result = JsonConvert.SerializeObject(target, options);
            if (isConvertSingleQuotes)
                result = result.Replace("\"", "'");
            return result;
        }

        /// <summary>
        /// 将对象转换为Json字符串，并且去除两侧括号
        /// </summary>
        /// <param name="target">目标对象</param>
        /// <param name="camelCase">是否驼峰命名</param>
        /// <param name="indented">是否缩排</param>
        /// <param name="isConvertSingleQuotes">是否将双引号转成单引号</param>
        public static string ToJsonWithoutBrackets(this object target, bool camelCase = false, bool indented = false, bool isConvertSingleQuotes = false)
        {
            var result = ToJsonString(target, camelCase, indented, isConvertSingleQuotes);
            if (result == "{}")
                return result;
            return result.TrimStart('{').TrimEnd('}');
        }
    }
}