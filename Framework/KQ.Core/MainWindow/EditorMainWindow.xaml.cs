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
            this.Width = 1280;
            this.Height = 960;

            Border_Menu.Child = Services.Module.GetWidget(EModuleType.EditorMenu);
            Border_Map.Child = Services.Module.GetWidget(EModuleType.EditorMap);
            Border_Status.Child = Services.Module.GetWidget(EModuleType.EditorStatusBar);
            Border_Browser.Child = Services.Module.GetWidget(EModuleType.EditorBrowser);
            Border_Property.Child = Services.Module.GetWidget(EModuleType.EditorProperty);
            Border_Output.Child = Services.Module.GetWidget(EModuleType.Output);
        }
    }
}
