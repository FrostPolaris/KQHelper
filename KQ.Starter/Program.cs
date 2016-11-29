using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KQ.Core;
using KQ.MapPanel;
using KQ.StatusBar;

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

            InitializeService();

            Application.Run();
        }

        private static void InitializeService()
        {
            List<IModule> allModules = new List<IModule>();
            allModules.Add(new StatusBarModule());
            allModules.Add(new MapModule());

            Services.Initialize(allModules);
            Services.TheMainWindow.Closed += MainWindowClosedHandler;
        }

        private static void MainWindowClosedHandler(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
