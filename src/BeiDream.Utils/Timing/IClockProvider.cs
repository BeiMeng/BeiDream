using System;

namespace BeiDream.Utils.Timing
{
    /// <summary>
    /// 定义执行一些常规的date-time操作的接口
    /// </summary>
    public interface IClockProvider
    {
        /// <summary>
        /// 获取当前时间
        /// </summary>
        DateTime Now { get; }

        /// <summary>
        /// 规范化给定的 <see cref="DateTime"/>.
        /// </summary>
        /// <param name="dateTime">要规范化的时间</param>
        /// <returns>规范化的时间</returns>
        DateTime Normalize(DateTime dateTime);
    }
}