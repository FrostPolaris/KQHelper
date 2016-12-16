using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KQ.Core
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class EditorMainWindow : Window
    {
        public EditorMainWindow()
        {
            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
            Border_Menu.Child = Services.Module.GetWidget(EModuleType.Menu);
            Border_Map.Child = Services.Module.GetWidget(EModuleType.Map);
            Border_Status.Child = Services.Module.GetWidget(EModuleType.StatusBar);
        }
    }
}
