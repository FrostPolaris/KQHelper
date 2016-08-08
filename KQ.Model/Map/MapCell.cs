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
        /// 在地图区块中的位置
        /// </summary>
        public MPosition RegionPosition { get; private set; }

        /// <summary>
        /// 父级地图区块
        /// </summary>
        public MapBlock ParentBlock { get; internal set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public MapCell()
            : this(0, 0)
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="x">在父区块中的X坐标</param>
        /// <param name="y">在父区块中的Y坐标</param>
        public MapCell(int x, int y)
            : this(new MPosition(x, y))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="position">在父区块中的位置</param>
        public MapCell(MPosition position)
        {
            this.RegionPosition = position;
        }
    }
}
