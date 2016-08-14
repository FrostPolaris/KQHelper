using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KQ.Core;
using KQ.Render;
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

            MainWindow mainWindow = new MainWindow();
            mainWindow.Closed += MainWindowClosedHandler;
            mainWindow.Show();

            Application.Run();
        }

        private static void InitializeService()
        {
            Services.Initialize();

            Services.ModuleManager.RegistModule(new StatusBarModule());
            Services.ModuleManager.RegistModule(new RenderModule());
            Services.ModuleManager.Initialize();

            Services.GameService.Initialize();
        }

        private static void MainWindowClosedHandler(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
