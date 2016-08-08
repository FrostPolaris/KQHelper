using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQ.Core
{
    /// <summary>
    /// 模块管理器
    /// </summary>
    public class ModuleManager
    {
        /// <summary>
        /// 实例
        /// </summary>
        public static ModuleManager Instance { get; private set; }

        static ModuleManager()
        {
            Instance = new ModuleManager();
        }

        /// <summary>
        /// 模块列表
        /// </summary>
        public IReadOnlyList<IModule> ModuleList
        {
            get { return _moduleList; }
        }
        private List<IModule> _moduleList = new List<IModule>();


        /// <summary>
        /// 注册模块
        /// </summary>
        /// <param name="module">想要注册的模块</param>
        public void RegistModule(IModule module)
        {
            _moduleList.Add(module);
        }

        /// <summary>
        /// 查找指定的模块
        /// </summary>
        /// <param name="moduleType">模块类型</param>
        /// <returns>想要查找的模块，未找到时返回空</returns>
        public IModule FindModule(EModuleType moduleType)
        {
            foreach(IModule module in ModuleList)
            {
                if (module.ModuleType == moduleType)
                    return module;
            }

            return null;
        }
    }
}
