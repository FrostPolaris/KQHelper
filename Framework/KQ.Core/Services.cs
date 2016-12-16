using System;
using System.Collections.Generic;
using System.Windows;
using KQ.Basic;
using KQ.Game;
using KQ.Model;

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
        /// 数据服务
        /// </summary>
        public static DataService Data { get; private set; }

        /// <summary>
        /// 主窗口实例
        /// </summary>
        public static Window TheMainWindow { get; private set; }

        /// <summary>
        /// 初始化服务
        /// </summary>
        /// <param name="appMode">软件模式</param>
        /// <param name="allModules">所有的模块</param>
        public static void Initialize(EAppMode appMode, IReadOnlyCollection<IModule> allModules)
        {
            AppInfo.Initialize(appMode);
            GlobalCommands.Initialize();

            Game = GameService.Instance;
            Game.Initialize();

            Module = new ModuleService();
            Module.Initialize(allModules);

            Data = DataService.Instance;

            switch (appMode)
            {
                case EAppMode.Editor:
                    TheMainWindow = new EditorMainWindow();
                    TheMainWindow.Show();
                    break;
            }

            CommandService.Initialize();
        }
    }
}
