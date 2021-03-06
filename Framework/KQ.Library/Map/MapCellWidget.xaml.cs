﻿using System;
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
    /// 地图单元格控件
    /// </summary>
    public partial class MapCellWidget : UserControl
    {
        public MapCell ContentCell { get; private set; }

        public MapCellWidget(MapCell cell)
        {
            InitializeComponent();

            ContentCell = cell;
            InitializeWidget();
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitializeWidget()
        {
            Border_Root.Width = Border_Root.Height = MapStyle.CellLenght - 2;
            Grid_BG.Background = MapStyle.GetCellBrush(ContentCell.TerrianType);
        }
    }
}
