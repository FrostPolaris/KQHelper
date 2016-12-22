using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KQ.Basic;
using KQ.Core;
using KQ.Editor.Browser;
using KQ.Editor.MapPanel;
using KQ.Editor.Menu;
using KQ.Editor.PropertyPanel;
using KQ.Editor.StatusBar;
using KQ.Output;

namespace KQ.Starter
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            InitializeAsEditorMode();
            Services.TheMainWindow.Closed += MainWindowClosedHandler;

            Application.Run();
        }

        /// <summary>
        /// 以“Game”模式初始化
        /// </summary>
        private static void InitializeAsGameMode()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 以“Editor”模式初始化
        /// </summary>
        private static void InitializeAsEditorMode()
        {
            List<IModule> allModules = new List<IModule>();
            allModules.Add(new StatusBarModule());
            allModules.Add(new MapModule());
            allModules.Add(new MenuModule());
            allModules.Add(new BrowserModule());
            allModules.Add(new PropertyModule());
            allModules.Add(new OutputModule());

            Services.Initialize(EAppMode.Editor, allModules);
        }

        private static void MainWindowClosedHandler(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
