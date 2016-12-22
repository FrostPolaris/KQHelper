using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using KQ.Core;

namespace KQ.Editor.StatusBar
{
    /// <summary>
    /// 状态栏模块
    /// </summary>
    public class StatusBarModule : IWidgetModule
    {
        EModuleType IModule.ModuleType
        {
            get { return EModuleType.EditorStatusBar; }
        }

        private StatusBar theStatusBar = new StatusBar();

        UserControl IWidgetModule.GetWidget()
        {
            return theStatusBar;
        }

        void IModule.Initialize()
        {
        }
    }
}
