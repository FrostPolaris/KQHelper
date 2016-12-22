using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KQ.Model.Data;

namespace KQ.Model
{
    /// <summary>
    /// 地图单元格类
    /// </summary>
    public class MapCell
    {
        /// <summary>
        /// 单元格的位置
        /// </summary>
        public Vector2D Position { get; private set; }

        /// <summary>
        /// 地形类型
        /// </summary>
        public ETerrianType TerrianType { get; set; }

        /// <summary>
        /// 持有自身的地图
        /// </summary>
        public Map Owner { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="owner">持有者地图</param>
        /// <param name="parent">在持有者地图中的位置</param>
        public MapCell(Map owner, Vector2D position)
        {
            this.Owner = owner;
            this.Position = position;
        }

        #region 反序列化

        /// <summary>
        /// 根据DataMapCell对象来创建MapCell对象
        /// </summary>
        /// <param name="dCell">DataMapCell对象</param>
        /// <param name="owner">单元格的持有地图</param>
        /// <returns>创建出来的MapCell对象</returns>
        internal static MapCell FromDataMapCell(DataMapCell dCell, Map owner)
        {
            MapCell cell = new MapCell();
            cell.Position = new Vector2D(dCell.PosX, dCell.PosY);
            cell.TerrianType = dCell.TerrianType;
            cell.Owner = owner;
            return cell;
        }

        /// <summary>
        /// 无参构造，在反序列化时使用
        /// </summary>
        private MapCell() { }

        #endregion


    }
}
