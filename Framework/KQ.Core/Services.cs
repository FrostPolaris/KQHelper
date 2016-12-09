using System;
using System.Collections.Generic;
using KQ.Game;

namespace KQ.Core
{
    /// <summary>
    /// 总服务类
    /// </summary>
    public static class Services
    {
        /// <summary>
        /// 模块服务
        /// </summary>
        internal static ModuleService Module { get; private set; }

        /// <summary>
        /// 游戏服务
        /// </summary>
        public static GameService Game { get; private set; }

        /// <summary>
        /// 主窗口实例
        /// </summary>
        public static MainWindow TheMainWindow { get; private set; }

        /// <summary>
        /// 初始化服务
        /// </summary>
        /// <param name="allModules">所有的模块</param>
        public static void Initialize(IReadOnlyCollection<IModule> allModules)
        {
            GlobalCommands.Initialize();

            Game = GameService.Instance;
            Game.Initialize();

            Module = new ModuleService();
            Module.Initialize(allModules);

            TheMainWindow = new MainWindow();
            TheMainWindow.Show();

            CommandService.Initialize();
        }
    }
}
