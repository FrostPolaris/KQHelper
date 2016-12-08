using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using KQ.Model;

namespace KQ.MapPanel
{
    /// <summary>
    /// 地图样式
    /// </summary>
    static class MapStyle
    {
        /// <summary>
        /// 单元格边长
        /// </summary>
        public const int CellLenght = 50;

        /// <summary>
        /// 保存了单元格笔刷信息的字典
        /// </summary>
        private static Dictionary<ETerrianType, SolidColorBrush> cellBrushed;

        /// <summary>
        /// 静态构造
        /// </summary>
        static MapStyle()
        {
            cellBrushed = new Dictionary<ETerrianType, SolidColorBrush>();
            cellBrushed[ETerrianType.Normal] = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            cellBrushed[ETerrianType.Blocked] = new SolidColorBrush(Color.FromRgb(211, 154, 104));
            cellBrushed[ETerrianType.Water] = new SolidColorBrush(Color.FromRgb(173, 198, 255));
            cellBrushed[ETerrianType.Teleport] = new SolidColorBrush(Color.FromRgb(255, 254, 173));
        }

        /// <summary>
        /// 获取单元格的笔刷
        /// </summary>
        /// <param name="terrian">地形类型</param>
        /// <returns>对应的笔刷</returns>
        public static SolidColorBrush GetCellBrush(ETerrianType terrian)
        {
            return cellBrushed[terrian];
        }
    }
}
