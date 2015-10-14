namespace BeiDream.Utils.Logging
{
    public class LoggingConfig
    {
        /// <summary>
        /// 获取或设置 从入口控制是否允许记录日志
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 获取或设置 入口允许记录的日志等级
        /// </summary>
        public LogLevel EntryLogLevel { get; set; }
    }
}