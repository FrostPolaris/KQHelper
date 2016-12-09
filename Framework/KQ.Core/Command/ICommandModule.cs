using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KQ.Core
{
    /// <summary>
    /// 带有命令的模块接口
    /// </summary>
    public interface ICommandModule : IModule
    {
        /// <summary>
        /// 绑定命令
        /// </summary>
        /// <param name="cmdCollection">命令集合</param>
        void BindCommands(CommandBindingCollection cmdCollection);
    }
}
