using System;
using System.Collections.Generic;
using System.IO;

namespace KQ.Basic
{
    /// <summary>
    /// 软件信息类
    /// </summary>
    public static class AppInfo
    {
        /// <summary>
        /// 当前软件模式
        /// </summary>
        public static EAppMode CurrentMode { get; private set; }

        /// <summary>
        /// 模拟器版本号
        /// </summary>
        public const string version = "0.0.0.1";

        /// <summary>
        /// 程序集所在目录
        /// </summary>
        public static string AssemblyDir { get; private set; }

        /// <summary>
        /// 日志所在目录
        /// </summary>
        public static string LogDir { get; private set; }
        private const string logFolderName = "Logs";

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="appMode">软件的模式</param>
        public static void Initialize(EAppMode appMode)
        {
            try
            {
                CurrentMode = appMode;
                AssemblyDir = AppDomain.CurrentDomain.BaseDirectory;

                List<string> dirList = new List<string>();
                LogDir = Path.Combine(AssemblyDir, logFolderName);
                dirList.Add(LogDir);

                foreach (string dir in dirList)
                {
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("初始化AppInfo失败。\r\n");
                Console.WriteLine(ex);
            }
        }
    }
}
