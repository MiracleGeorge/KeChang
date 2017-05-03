using log4net;
using log4net.Config;

namespace YouHoo.DataTools
{
    /// <summary>
    /// ��־������
    /// </summary>
    public class Logger
    {
        static Logger()
        {
            XmlConfigurator.Configure();
        }

        private static readonly ILog Log = LogManager.GetLogger("YouHoo");

        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <param name="sMessage"></param>
        public static void Debug(string sMessage)
        {
            Log.Debug(sMessage);
        }

        /// <summary>
        /// һ����Ϣ
        /// </summary>
        public static void Info(string sMessage)
        {
            Log.Info(sMessage);
        }

        /// <summary>
        /// ����
        /// </summary>
        public static void Warn(string sMessage)
        {
            Log.Warn(sMessage);
        }

        /// <summary>
        /// ��������
        /// </summary>
        public static void Error(string sMessage)
        {
            Log.Error(sMessage);
        }

        /// <summary>
        /// �����Ĵ���
        /// </summary>
        public static void Fatal(string sMessage)
        {
            Log.Fatal(sMessage);
        }
    }
}