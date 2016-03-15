using System;

namespace BeiDream.Utils.Timing
{
    /// <summary>
    /// 定义时间范围的接口
    /// </summary>
    public interface IDateTimeRange
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        DateTime EndTime { get; set; }
    }
}
