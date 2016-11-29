using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// 持有自身的MapBlock
        /// </summary>
        public MapBlock OwningBlock { get; internal set; }

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

    }
}
