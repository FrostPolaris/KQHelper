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
    /// 地图单元格控件
    /// </summary>
    public partial class MapCellWidget : UserControl
    {
        /// <summary>
        /// 单元格边长（单位：像素）
        /// </summary>
        public const int CellLenght = 50;

        private MapCell relatedMapCell;

        public MapCellWidget()
        {
            InitializeComponent();
            Border_Root.Width = Border_Root.Height = CellLenght - 2;
        }

        public MapCellWidget(MapCell cell)
        {
            InitializeComponent();
            relatedMapCell = cell;
            Border_Root.Width = Border_Root.Height = CellLenght - 2;
        }
    }
}
