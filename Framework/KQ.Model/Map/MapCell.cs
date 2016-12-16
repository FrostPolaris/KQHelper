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
        /// 单元格的位置（全局坐标）
        /// </summary>
        public Vector2D Position { get; private set; }

        /// <summary>
        /// 地形类型
        /// </summary>
        public ETerrianType TerrianType { get; set; }

        /// <summary>
        /// 持有自身的MapBlock
        /// </summary>
        public MapBlock OwningBlock { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parent">父级MapBlock</param>
        /// <param name="x">单元格位置的X坐标</param>
        /// <param name="y">单元格位置的Y坐标</param>
        public MapCell(MapBlock parent, int x, int y)
            : this(parent, new Vector2D(x, y))
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parent">父级MapBlock</param>
        /// <param name="position">单元格的位置</param>
        public MapCell(MapBlock parent, Vector2D position)
        {
            Position = position;
            OwningBlock = parent;
        }

        #region 反序列化

        /// <summary>
        /// 根据DataMapCell对象来创建MapCell对象
        /// </summary>
        /// <param name="dCell">DataMapCell对象</param>
        /// <param name="owningBlock">单元格的持有区块</param>
        /// <returns>创建出来的MapCell对象</returns>
        internal static MapCell FromDataMapCell(DataMapCell dCell, MapBlock owningBlock)
        {
            MapCell cell = new MapCell();
            cell.Position = new Vector2D(dCell.PosX, dCell.PosY);
            cell.TerrianType = dCell.TerrianType;
            cell.OwningBlock = owningBlock;
            return cell;
        }

        /// <summary>
        /// 无参构造，在反序列化时使用
        /// </summary>
        private MapCell() { }

        #endregion


    }
}
