using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KQ.Core
{
    /// <summary>
    /// 全局命令类
    /// </summary>
    public static class GlobalCommands
    {
        #region 初始化

        /// <summary>
        /// 初始化所有全局命令
        /// </summary>
        public static void Initialize()
        {
            Load = CreateCommand("加载", Key.L);
            Quit = CreateCommand("退出", Key.Q);
            About = CreateCommand("关于");
            GenerateTestData = CreateCommand("生成测试数据");
        }

        /// <summary>
        /// 创建命令
        /// </summary>
        /// <param name="cmdName">命令名称</param>
        /// <returns>创建出来的命令</returns>
        private static RoutedCommand CreateCommand(string cmdName)
        {
            return new RoutedCommand(cmdName, typeof(GlobalCommands));
        }

        /// <summary>
        /// 创建带有快捷键的命令
        /// </summary>
        /// <param name="cmdName">命令名称</param>
        /// <param name="hotkey">快捷键</param>
        /// <returns>创建出来的命令</returns>
        private static RoutedCommand CreateCommand(string cmdName, Key hotkey)
        {
            InputGestureCollection input = new InputGestureCollection();
            input.Add(new KeyGesture(hotkey, ModifierKeys.Control, string.Format("Ctrl+{0}", hotkey)));
            return new RoutedCommand(cmdName, typeof(GlobalCommands), input);
        }

        #endregion

        #region 命令列表

        /// <summary>
        /// 加载命令
        /// </summary>
        public static RoutedCommand Load { get; private set; }

        /// <summary>
        /// 退出命令
        /// </summary>
        public static RoutedCommand Quit { get; private set; }

        /// <summary>
        /// 关于命令
        /// </summary>
        public static RoutedCommand About { get; private set; }

        /// <summary>
        /// 生成测试数据命令
        /// </summary>
        public static RoutedCommand GenerateTestData { get; private set; }

        #endregion

    }
}
