using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KQ.Core
{
    /// <summary>
    /// 主窗口内容接口
    /// </summary>
    public interface IMainWindowContent
    {
        /// <summary>
        /// 名称
        /// </summary>
        string ContentName { get; }

        /// <summary>
        /// 获取控件
        /// </summary>
        /// <returns>对应的控件</returns>
        UserControl GetControl();
    }
}
