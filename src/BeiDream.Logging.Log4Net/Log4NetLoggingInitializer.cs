using BeiDream.Utils.Logging;

namespace BeiDream.Logging.Log4Net
{
    /// <summary>
    /// log4net日志初始化器，用于初始化基础日志功能
    /// </summary>
    public class Log4NetLoggingInitializer
    {
         //<summary>
         //开始初始化基础日志
         //</summary>
         //<param name="config">日志配置信息</param>
        public static void Initialize(LoggingConfig config)
        {
            LogManager.SetEntryInfo(config.Enabled, config.EntryLogLevel);
            LogManager.AddLoggerAdapter(new Log4NetLoggerAdapter());
        }
    }
}