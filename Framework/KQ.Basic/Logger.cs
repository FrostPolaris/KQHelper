using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQ.Basic
{
    /// <summary>
    /// 日志工具
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// 日志记录事件
        /// </summary>
        public static event Action<string> LogRecorded;

        /// <summary>
        /// 日志文件的保存路径
        /// </summary>
        private static string filePath = string.Empty;

        #region 初始化

        static Logger()
        {
            Initialize();
        }

        /// <summary>
        /// 初始化日志工具
        /// </summary>
        private static void Initialize()
        {
            string curTime = System.DateTime.Now.ToString();
            string fileName = string.Format("Log {0}.txt", curTime.Replace("/", "_").Replace(":", "."));
            filePath = Path.Combine(AppInfo.LogDir, fileName);
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 以[INFO]等级记录日志
        /// </summary>
        /// <param name="message">需要记录的信息</param>
        public static void Info(object message)
        {
            Info(message, null);
        }

        /// <summary>
        /// 以[INFO]等级记录日志
        /// </summary>
        /// <param name="message">需要记录的信息</param>
        /// <param name="exception">异常信息</param>
        public static void Info(object message, Exception exception)
        {
            Log(message, exception, "INFO");
        }

        /// <summary>
        /// 以[WARRNING]等级记录日志
        /// </summary>
        /// <param name="message">需要记录的信息</param>
        public static void Warrning(object message)
        {
            Warrning(message, null);
        }

        /// <summary>
        /// 以[WARRNING]等级记录日志
        /// </summary>
        /// <param name="message">需要记录的信息</param>
        /// <param name="exception">异常信息</param>
        public static void Warrning(object message, Exception exception)
        {
            Log(message, exception, "WARRNING");
        }

        /// <summary>
        /// 以[ERROR]等级记录日志
        /// </summary>
        /// <param name="message">需要记录的信息</param>
        public static void Error(object message)
        {
            Error(message, null);
        }

        /// <summary>
        /// 以[ERROR]等级记录日志
        /// </summary>
        /// <param name="message">需要记录的信息</param>
        /// <param name="exception">异常信息</param>
        public static void Error(object message, Exception exception)
        {
            Log(message, exception, "ERROR");
        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="message">需要记录的信息</param>
        /// <param name="exception">异常信息</param>
        /// <param name="logLevel">日志等级</param>
        private static void Log(object message, Exception exception, string logLevel)
        {
            string messageStr;
            if (message == null)
            {
                messageStr = string.Format("[{0}] ", logLevel);
            }
            else
            {
                messageStr = string.Format("[{0}] {1}", logLevel, message);
            }

            string exceptionStr = string.Empty;
            if (exception != null)
            {
                exceptionStr = exception.ToString();
            }

            PrintToConsole(messageStr, exceptionStr);
            WriteInfo(messageStr, exceptionStr);
            RaiseLogRecorded(messageStr);
        }

        /// <summary>
        /// 将信息打印到控制台
        /// </summary>
        /// <param name="messageStr">需要记录的信息</param>
        /// <param name="exception">异常信息</param>
        private static void PrintToConsole(string messageStr, string exceptionStr)
        {
            if (!string.IsNullOrEmpty(messageStr))
            {
                Console.WriteLine(messageStr);
            }

            if (!string.IsNullOrEmpty(exceptionStr))
            {
                Console.WriteLine(exceptionStr);
            }
        }

        /// <summary>
        /// 向日志文件中写入信息
        /// </summary>
        /// <param name="message">需要记录的信息</param>
        /// <param name="exception">异常信息</param>
        private static void WriteInfo(string messageStr, string exceptionStr)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    if (!string.IsNullOrEmpty(messageStr))
                    {
                        sw.WriteLine(messageStr);
                    }

                    if (!string.IsNullOrEmpty(exceptionStr))
                    {
                        sw.WriteLine(exceptionStr);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("写入调试日志时出错");
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// 发起日志记录事件
        /// </summary>
        /// <param name="message">输出信息</param>
        private static void RaiseLogRecorded(string messageStr)
        {
            if (string.IsNullOrEmpty(messageStr))
                return;

            if (LogRecorded != null)
            {
                LogRecorded(messageStr);
            }
        }

        #endregion
    }
}
