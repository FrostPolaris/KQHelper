using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KQ.Core
{
    /// <summary>
    /// 用户控件接口
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// 模块类型
        /// </summary>
        EModuleType ModuleType { get; }

        /// <summary>
        /// 获取用户控件
        /// </summary>
        /// <returns>用户控件</returns>
        UserControl GetUserControl();
    }
}
