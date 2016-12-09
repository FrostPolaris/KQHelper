using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KQ.Core
{
    /// <summary>
    /// 命令服务
    /// </summary>
    internal static class CommandService
    {
        #region 初始化

        /// <summary>
        /// 初始化
        /// </summary>
        internal static void Initialize()
        {
            if (Services.TheMainWindow == null)
            {
                throw new InvalidOperationException("应当在主窗口创建之后再初始化命令服务");
            }

            CommandBindingCollection cmdCollection = Services.TheMainWindow.CommandBindings;
            BindGlobalCommandHandler(cmdCollection);
            BindCustomCommandHandler(cmdCollection);
        }

        /// <summary>
        /// 绑定全局命令
        /// </summary>
        private static void BindGlobalCommandHandler(CommandBindingCollection cmdBindCollection)
        {
            CommandBinding saveBinding = new CommandBinding(ApplicationCommands.Save);
            saveBinding.Executed += SaveBinding_Executed;
            saveBinding.CanExecute += SaveBinding_CanExecute;
            cmdBindCollection.Add(saveBinding);

            CommandBinding loadBinding = new CommandBinding(GlobalCommands.Load);
            loadBinding.Executed += LoadBinding_Executed;
            cmdBindCollection.Add(loadBinding);

            CommandBinding quitBinding = new CommandBinding(GlobalCommands.Quit);
            quitBinding.Executed += QuitBinding_Executed;
            quitBinding.CanExecute += QuitBinding_CanExecute;
            cmdBindCollection.Add(quitBinding);

            CommandBinding aboutBinding = new CommandBinding(GlobalCommands.About);
            aboutBinding.Executed += AboutBinding_Executed;
            cmdBindCollection.Add(aboutBinding);
        }

        /// <summary>
        /// 绑定自定义命令
        /// </summary>
        private static void BindCustomCommandHandler(CommandBindingCollection cmdBindCollection)
        {
            foreach (ICommandModule cmdModule in Services.Module.GetAllModules<ICommandModule>())
            {
                cmdModule.BindCommands(cmdBindCollection);
            }
        }

        #endregion

        #region 命令处理

        private static void LoadBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //Services.TheTemplateService.Load();
            //Logger.Info("模板加载完成。");
        }

        private static void SaveBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //Services.GetService<IPropertyGridService>().ForceApply();

            //ProcessLogger logger = new ProcessLogger();
            //if (!Services.TheTemplateService.Validate(logger))
            //{
            //    StringBuilder sb = new StringBuilder();
            //    sb.AppendLine("模板数据未能通过合法性校验，具体错误如下：");
            //    foreach (string log in logger.Logs)
            //    {
            //        sb.AppendLine(log);
            //    }
            //    Logger.Error(sb.ToString());
            //}
            //else
            //{
            //    Services.TheTemplateService.Save();
            //    Logger.Info("模板保存完成。");
            //}
        }

        private static void SaveBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            //e.CanExecute = true;
        }

        private static void QuitBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Services.TheMainWindow.Close();
        }

        private static void QuitBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Services.TheMainWindow != null;
        }

        private static void AboutBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //AboutWindow wnd = new AboutWindow();
            //wnd.Owner = Services.TheMainWindow;
            //wnd.ShowDialog();
        }

        #endregion
    }
}
