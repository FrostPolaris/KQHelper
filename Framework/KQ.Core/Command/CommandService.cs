using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KQ.Model;

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

            CommandBinding generateTestBinding = new CommandBinding(GlobalCommands.GenerateTestData);
            generateTestBinding.Executed += GenerateTestBinding_Executed;
            cmdBindCollection.Add(generateTestBinding);
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
            Services.Data.LoadAll();
        }

        private static void SaveBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Services.Data.SaveAll();
        }

        private static void SaveBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
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

        private static void GenerateTestBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Map testMap = new Map("测试地图");
            testMap.AppendBlock(0, 0, 8, 8);
            testMap.AppendBlock(0, 8, 8, 8);
            testMap.AppendBlock(8, 0, 8, 8);
            testMap.AppendBlock(8, 8, 8, 8);

            Services.Data.Maps.Add(testMap);
        }

        #endregion
    }
}
