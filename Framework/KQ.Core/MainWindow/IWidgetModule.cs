﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KQ.Core
{
    /// <summary>
    /// 主窗口部件接口
    /// </summary>
    public interface IWidgetModule : IModule
    {
        /// <summary>
        /// 获取部件
        /// </summary>
        /// <returns>对应的部件</returns>
        UserControl GetWidget();
    }
}
