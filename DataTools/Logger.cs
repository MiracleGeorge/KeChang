using log4net;
using log4net.Config;

namespace YouHoo.DataTools
{
    /// <summary>
    /// 日志管理类
    /// </summary>
    public class Logger
    {
        static Logger()
        {
            XmlConfigurator.Configure();
        }

        private static readonly ILog Log = LogManager.GetLogger("YouHoo");

        /// <summary>
        /// 调试信息
        /// </summary>
        /// <param name="sMessage"></param>
        public static void Debug(string sMessage)
        {
            Log.Debug(sMessage);
        }

        /// <summary>
        /// 一般信息
        /// </summary>
        public static void Info(string sMessage)
        {
            Log.Info(sMessage);
        }

        /// <summary>
        /// 警告
        /// </summary>
        public static void Warn(string sMessage)
        {
            Log.Warn(sMessage);
        }

        /// <summary>
        /// 发生错误
        /// </summary>
        public static void Error(string sMessage)
        {
            Log.Error(sMessage);
        }

        /// <summary>
        /// 致命的错误
        /// </summary>
        public static void Fatal(string sMessage)
        {
            Log.Fatal(sMessage);
        }
    }
}