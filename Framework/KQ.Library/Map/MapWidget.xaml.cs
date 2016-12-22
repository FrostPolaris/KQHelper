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

namespace KQ.Library
{
    /// <summary>
    /// MapWidget.xaml 的交互逻辑
    /// </summary>
    public partial class MapWidget : UserControl
    {
        public Map ContentMap { get; private set; }

        public MapWidget(Map map)
        {
            InitializeComponent();
            Reset(map);
        }

        /// <summary>
        /// 使用新的地图数据重置地图控件
        /// </summary>
        /// <param name="map">新的地图数据</param>
        public void Reset(Map map)
        {
            ContentMap = map;
            Canvas_Root.Width = MapStyle.CellLenght * map.Size.X;
            Canvas_Root.Height = MapStyle.CellLenght * map.Size.Y;

            foreach (MapBlock block in map.BlockList)
            {
                MapBlockWidget blockWidget = new MapBlockWidget(block);
                Canvas_Root.Children.Add(blockWidget);
                Canvas.SetLeft(blockWidget, (block.Position.X - map.Position.X) * MapStyle.CellLenght);
                Canvas.SetRight(blockWidget, (block.Position.X + block.Size.X - map.Position.X) * MapStyle.CellLenght);
                Canvas.SetTop(blockWidget, (block.Position.Y - map.Position.Y) * MapStyle.CellLenght);
                Canvas.SetBottom(blockWidget, (block.Position.Y + block.Size.Y - map.Position.Y) * MapStyle.CellLenght);
            }
        }
    }
}
