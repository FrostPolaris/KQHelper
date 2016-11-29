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
using KQ.Model;

namespace KQ.MapPanel
{
    /// <summary>
    /// MapWidget.xaml 的交互逻辑
    /// </summary>
    public partial class MapWidget : UserControl
    {

        public MapWidget()
        {
            InitializeComponent();
        }

        public MapWidget(Map map)
        {
            InitializeComponent();
            Initialize(map);
        }

        public void Initialize(Map map)
        {
            Canvas_Root.Width = MapCellWidget.CellLenght * map.Size.X + 10;
            Canvas_Root.Height = MapCellWidget.CellLenght * map.Size.Y + 10;

            foreach (MapBlock block in map.BlockList)
            {
                MapBlockWidget blockWidget = new MapBlockWidget(block);
                Canvas_Root.Children.Add(blockWidget);
                Canvas.SetLeft(blockWidget, (block.Position.X - map.Position.X) * MapCellWidget.CellLenght);
                Canvas.SetRight(blockWidget, (block.Position.X + block.Size.X - map.Position.X) * MapCellWidget.CellLenght);
                Canvas.SetTop(blockWidget, (block.Position.Y - map.Position.Y) * MapCellWidget.CellLenght);
                Canvas.SetBottom(blockWidget, (block.Position.Y + block.Size.Y - map.Position.Y) * MapCellWidget.CellLenght);
            }
        }
    }
}
