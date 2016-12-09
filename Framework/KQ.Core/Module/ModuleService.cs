using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KQ.Core
{
    /// <summary>
    /// 模块管理器
    /// </summary>
    class ModuleService
    {
        /// <summary>
        /// 所有的模块
        /// </summary>
        private List<IModule> allModules = new List<IModule>();

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="modules">需要注册的模块</param>
        public void Initialize(IReadOnlyCollection<IModule> modules)
        {
            foreach (IModule module in modules)
            {
                allModules.Add(module);
                module.Initialize();
            }
        }

        /// <summary>
        /// 获取模块
        /// </summary>
        /// <param name="moduleType">模块类型</param>
        /// <returns>想要查找的模块，未找到时返回空</returns>
        public IModule GetModule(EModuleType moduleType)
        {
            return allModules.Find(m => m.ModuleType.Equals(moduleType));
        }

        /// <summary>
        /// 获取指定类型的所有模块
        /// </summary>
        /// <typeparam name="T">想要获取的模块类型</typeparam>
        /// <returns>指定类型的所有模块</returns>
        public IEnumerable<T> GetAllModules<T>()
            where T : class, IModule
        {
            List<T> resList = new List<T>();
            foreach(IModule module in allModules)
            {
                T targetModule = module as T;
                if (targetModule != null)
                {
                    resList.Add(targetModule);
                }
            }

            return resList;
        }

        /// <summary>
        /// 获取部件
        /// </summary>
        /// <param name="moduleType">部件所在模块的模块类型</param>
        /// <returns>主窗口部件</returns>
        public UserControl GetWidget(EModuleType moduleType)
        {
            foreach (IModule module in allModules.FindAll(m => m.ModuleType == moduleType))
            {
                IWidgetModule widgetModule = module as IWidgetModule;
                if (widgetModule != null)
                {
                    return widgetModule.GetWidget();
                }
            }
            return null;
        }
    }
}
