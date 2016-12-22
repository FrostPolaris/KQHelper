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
using System.Windows.Navigation;
using System.Windows.Shapes;
using KQ.Core;
using KQ.Library;

namespace KQ.Editor.MapPanel
{
    /// <summary>
    /// MapPanel.xaml 的交互逻辑
    /// </summary>
    public partial class MapPanel : UserControl
    {
        public MapPanel()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            MapWidget mapWidget = new MapWidget(Services.Game.TheGameInstance.CurrentMap);
            Grid_Root.Children.Add(mapWidget);
            mapWidget.HorizontalAlignment = HorizontalAlignment.Center;
            mapWidget.VerticalAlignment = VerticalAlignment.Center;
        }
    }
}
