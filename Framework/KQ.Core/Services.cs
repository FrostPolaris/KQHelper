using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KQ.GamePlay;

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
        /// 游戏服务
        /// </summary>
        public static GameService GameService { get; private set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="moduleList">模块列表</param>
        public static void Initialize()
        {
            ModuleManager = ModuleManager.Instance;
            GameService = GameService.Instance;
        }
    }
}
