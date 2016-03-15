using System;

namespace BeiDream.Utils.Timing
{
    /// <summary>
    /// 实现接口 <see cref="IClockProvider"/>，以提供UTC时间.
    /// </summary>
    public class UtcClockProvider : IClockProvider
    {
        /// <summary>
        /// 获取当前时间
        /// </summary>
        public DateTime Now
        {
            get { return DateTime.UtcNow; }
        }

        /// <summary>
        /// 规范化给定的 <see cref="DateTime"/>.
        /// </summary>
        /// <param name="dateTime">要规范化的时间</param>
        /// <returns>规范化的时间</returns>
        public DateTime Normalize(DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Unspecified)
            {
                return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            }

            if (dateTime.Kind == DateTimeKind.Local)
            {
                return dateTime.ToUniversalTime();
            }

            return dateTime;
        }
    }
}