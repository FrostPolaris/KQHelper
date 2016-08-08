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
        /// <summary>
        /// 模块类型
        /// </summary>
        public EModuleType ModuleType
        {
            get { return EModuleType.StatusBar; }
        }

        /// <summary>
        /// 状态栏控件
        /// </summary>
        private StatusBar statusBar;

        /// <summary>
        /// 获取用户控件
        /// </summary>
        /// <returns></returns>
        public UserControl GetUserControl()
        {
            if (statusBar == null)
                statusBar = new StatusBar();

            return statusBar;
        }
    }
}
