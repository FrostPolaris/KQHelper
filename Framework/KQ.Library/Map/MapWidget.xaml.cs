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

            //为地图设置行列
            for (int x = 0; x < ContentMap.Size.X; x++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                colDef.Width = GridLength.Auto;
                Grid_Root.ColumnDefinitions.Add(colDef);
            }
            for (int y = 0; y < ContentMap.Size.Y; y++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = GridLength.Auto;
                Grid_Root.RowDefinitions.Add(rowDef);
            }

            //向地图中添加单元格
            for (int x = 0; x < ContentMap.Size.X; x++)
            {
                for (int y = 0; y < ContentMap.Size.Y; y++)
                {
                    MapCell cell = ContentMap.GetCell(x, y);
                    MapCellWidget cellWidget = new MapCellWidget(cell);
                    Grid_Root.Children.Add(cellWidget);

                    Grid.SetColumn(cellWidget, x);
                    Grid.SetRow(cellWidget, y);
                }
            }
        }
    }
}
