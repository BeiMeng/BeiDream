using System;

namespace BeiDream.Utils.Timing
{
    /// <summary>
    /// 用于执行一些常规的date-time操作
    /// </summary>
    public static class Clock
    {
        /// <summary>
        /// 这个对象用于执行所有的<see cref="Clock"/>操作
        /// Default value: <see cref="LocalClockProvider"/>.
        /// </summary>
        public static IClockProvider Provider
        {
            get { return _provider; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Can not set Clock to null!");
                }

                _provider = value;
            }
        }
        private static IClockProvider _provider;

        /// <summary>
        /// 构造函数
        /// </summary>
        static Clock()
        {
            Provider = new LocalClockProvider();
        }

        /// <summary>
        /// 使用 <see cref="Provider"/>获取当前时间.
        /// </summary>
        public static DateTime Now
        {
            get { return Provider.Now; }
        }

        /// <summary>
        /// 使用当前的 <see cref="Provider"/>，规范化给定的 <see cref="DateTime"/>
        /// </summary>
        /// <param name="dateTime">要规范化的时间</param>
        /// <returns>规范化后的时间</returns>
        public static DateTime Normalize(DateTime dateTime)
        {
            return Provider.Normalize(dateTime);
        }
    }
}