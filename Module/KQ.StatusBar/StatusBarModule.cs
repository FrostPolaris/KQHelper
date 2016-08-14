using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using KQ.Core;

namespace KQ.StatusBar
{
    /// <summary>
    /// 状态栏模块
    /// </summary>
    public class StatusBarModule : IModule
    {
        public string ModuleName
        {
            get { return "StatusBar"; }
        }

        private StatusBar theStatusBar = new StatusBar();

        public void Initialize()
        {
            MainWindowController.Instance.RegistContent(theStatusBar);
        }
    }
}
