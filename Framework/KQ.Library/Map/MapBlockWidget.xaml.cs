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
    /// MapBlockWidget.xaml 的交互逻辑
    /// </summary>
    public partial class MapBlockWidget : UserControl
    {
        private MapBlock relateMapBlock;

        public MapBlockWidget()
        {
            InitializeComponent();
        }

        public MapBlockWidget(MapBlock block)
        {
            InitializeComponent();
            Initialize(block);
        }

        private void Initialize(MapBlock block)
        {
            relateMapBlock = block;

            //为区块设置行列
            for (int x = 0; x < relateMapBlock.Size.X; x++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                colDef.Width = GridLength.Auto;
                Grid_Root.ColumnDefinitions.Add(colDef);
            }
            for (int y = 0; y < relateMapBlock.Size.Y; y++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = GridLength.Auto;
                Grid_Root.RowDefinitions.Add(rowDef);
            }

            //向区块中添加单元格
            for (int x = 0; x < relateMapBlock.Size.X; x++)
            {
                for (int y = 0; y < relateMapBlock.Size.Y; y++)
                {
                    MapCell cell = relateMapBlock.GetMapCell(x, y);
                    MapCellWidget cellWidget = new MapCellWidget(cell);
                    Grid_Root.Children.Add(cellWidget);

                    Grid.SetColumn(cellWidget, x);
                    Grid.SetRow(cellWidget, y);
                }
            }
        }

    }
}
