using BeiDream.Logging.Log4Net;
using BeiDream.Utils.Logging;

namespace BeiDream.Demo.Web
{
    /// <summary>
    /// 日志初始化
    /// </summary>
    public class LogConfig
    {
        public static void Initialize()
        {
            Log4NetLoggingInitializer.Initialize(new LoggingConfig(true, LogLevel.All));
        }
    }
}