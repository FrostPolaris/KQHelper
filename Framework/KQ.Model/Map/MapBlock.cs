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
        /// 区块在父级Map中的位置（左上角单元格的位置）
        /// </summary>
        public Vector2D Position { get; private set; }

        /// <summary>
        /// 区块的尺寸
        /// </summary>
        public Vector2D Size { get; private set; }

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
            get { return Position.X + Size.X - 1; }
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
            get { return Position.Y + Size.Y - 1; }
        }

        /// <summary>
        /// 父级地图
        /// </summary>
        public Map OwningMap { get; private set; }

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

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parent">父级地图</param>
        /// <param name="x">区块位置的X坐标</param>
        /// <param name="y">区块位置的Y坐标</param>
        /// <param name="w">区块的宽度</param>
        /// <param name="h">区块的高度</param>
        public MapBlock(Map parent, int x, int y, int w, int h)
            : this(parent, new Vector2D(x, y), new Vector2D(w, h))
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parent">父级地图</param>
        /// <param name="position">区块的位置</param>
        /// <param name="size">区块的尺寸</param>
        public MapBlock(Map parent, Vector2D position, Vector2D size)
        {
            this.Position = position;
            this.Size = size;

            if (Size.X <= 0 || Size.Y <= 0)
            {
                throw new ArgumentException("区块尺寸的X和Y必须均为正整数。");
            }

            for (int x = 0; x < Size.X; x++)
            {
                for (int y = 0; y < Size.Y; y++)
                {
                    MapCell newCell = new MapCell(this, Position.X + x, Position.Y + y);
                    mapCellList.Add(newCell);
                }
            }
        }
        #endregion

        #region 公有方法

        /// <summary>
        /// 获取单元格
        /// </summary>
        /// <param name="indexX">单元格在区块内的X索引</param>
        /// <param name="indexY">单元格在区块内的Y索引</param>
        /// <returns></returns>
        public MapCell GetMapCell(int indexX, int indexY)
        {
            if (indexX < 0 || indexX >= Size.X
                || indexY < 0 || indexY >= Size.Y)
            {
                return null;
            }

            int index = Size.X * indexY + indexX;
            return mapCellList[index];
        }

        /// <summary>
        /// 检测某一区块是否与自身重合(按位置和尺寸计算，不考虑是否为同一父级地图)
        /// </summary>
        /// <param name="other">其它区块</param>
        /// <returns>是否重合</returns>
        public bool CheckIsOverlapped(MapBlock other)
        {
            if (other.OwningMap != this.OwningMap)
            {
                return false;
            }

            if (other.MaxX < this.MinX || other.MinX > this.MaxX ||
                other.MaxY < this.MinY || other.MinY > this.MaxY)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
