using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQ.Core
{
    /// <summary>
    /// 总服务类
    /// </summary>
    public static class Services
    {
        /// <summary>
        /// 模块管理器
        /// </summary>
        public static ModuleManager ModuleManager { get; private set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="moduleList">模块列表</param>
        public static void Initialize()
        {
            ModuleManager = ModuleManager.Instance;
        }
    }
}
