using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQ.Model
{
    /// <summary>
    /// 地图区块类
    /// </summary>
    public class MapBlock
    {
        #region 属性与字段
        /// <summary>
        /// 区块在父地图中的整体位置
        /// </summary>
        public MPosition Position { get; private set; }

        /// <summary>
        /// 所占区域的最小X坐标
        /// </summary>
        public int MinX
        {
            get { return Position.X; }
        }

        /// <summary>
        /// 所占区域的最大X坐标
        /// </summary>
        public int MaxX
        {
            get { return Position.X + Size.Width - 1; }
        }

        /// <summary>
        /// 所占区域的最小Y坐标
        /// </summary>
        public int MinY
        {
            get { return Position.Y; }
        }

        /// <summary>
        /// 所占区域的最大Y坐标
        /// </summary>
        public int MaxY
        {
            get { return Position.Y + Size.Height - 1; }
        }

        /// <summary>
        /// 区块的尺寸
        /// </summary>
        public MSize Size { get; private set; }

        /// <summary>
        /// 父级地图
        /// </summary>
        public Map ParentMap { get; internal set; }

        /// <summary>
        /// 单元格列表
        /// </summary>
        public IReadOnlyList<MapCell> MapCellList
        {
            get { return mapCellList; }
        }
        private List<MapCell> mapCellList = new List<MapCell>();
        #endregion

        #region 构造与初始化
        public MapBlock()
            : this(0, 0, 0, 0)
        {
        }

        public MapBlock(int x, int y, int w, int h)
            : this(new MPosition(x, y), new MSize(w, h))
        {
        }

        public MapBlock(MPosition position, MSize size)
        {
            this.Position = position;
            this.Size = size;
            if (this.Position == null)
                this.Position = new MPosition();
            if (this.Size == null)
                this.Size = new MSize();

            for (int x = 0; x < Size.Width; x++)
            {
                for (int y = 0; y < Size.Height; y++)
                {
                    MapCell newCell = new MapCell(x, y);
                    newCell.ParentBlock = this;
                    mapCellList.Add(newCell);
                }
            }
        }
        #endregion

        #region 公有方法
        /// <summary>
        /// 检测某一区块是否与自身重合(按位置和尺寸计算，不考虑是否为同一父级地图)
        /// </summary>
        /// <param name="other">其它区块</param>
        /// <returns>是否重合</returns>
        public bool CheckIsOverlapped(MapBlock other)
        {
            if (other.MaxX < this.MinX || other.MinX > this.MaxX ||
                other.MaxY < this.MinY || other.MinY > this.MaxY)
                return false;

            return true;
        }
        #endregion
    }
}
