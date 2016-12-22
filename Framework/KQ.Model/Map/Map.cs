using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KQ.Model.Data;

namespace KQ.Model
{
    /// <summary>
    /// 地图类
    /// </summary>
    public class Map
    {
        /// <summary>
        /// 地图名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 地图的尺寸
        /// </summary>
        public Vector2D Size { get; private set; }

        /// <summary>
        /// 地图单元格列表
        /// </summary>
        public IReadOnlyList<MapCell> CellList
        {
            get { return _cellList; }
        }
        private List<MapCell> _cellList = new List<MapCell>();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">地图名称</param>
        /// <param name="w">地图宽度</param>
        /// <param name="h">地图高度</param>
        public Map(string name, int w, int h)
            : this(name, new Vector2D(w, h))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">地图名称</param>
        /// <param name="size">地图尺寸</param>
        public Map(string name, Vector2D size)
        {
            this.Name = name;
            this.Size = size;
            if (!Size.IsValidSize())
            {
                throw new ArgumentException("使用了非法的地图尺寸：" + size);
            }

            Initialize();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialize()
        {
            _cellList.Clear();
            for (int x = 0; x < Size.X; x++)
            {
                for (int y = 0; y < Size.Y; y++)
                {
                    MapCell cell = new MapCell(this, new Vector2D(x, y));
                    _cellList.Add(cell);
                }
            }
        }

        /// <summary>
        /// 通过坐标位置获取单元格
        /// </summary>
        /// <param name="x">X坐标</param>
        /// <param name="y">Y坐标</param>
        /// <returns></returns>
        public MapCell GetCell(int x, int y)
        {
            if (x < 0 || x >= Size.X || y < 0 || y >= Size.Y)
            {
                return null;
            }
            int index = y * Size.X + x;
            return CellList[index];
        }

        /// <summary>
        /// 扩展地图尺寸
        /// </summary>
        /// <param name="direction">扩展的方向</param>
        /// <param name="length">扩展的长度</param>
        public void AppendSize(EDirection direction, uint length)
        {

        }

        /// <summary>
        /// 收缩地图尺寸
        /// </summary>
        /// <param name="fromDir">收缩的方向</param>
        /// <param name="length">收缩的长度</param>
        public void ShrinkSize(EDirection fromDir, uint length)
        {

        }

        public override string ToString()
        {
            return string.Format("地图：{0}  尺寸：({1})", Name, Size);
        }

        #region 反序列化

        internal static Map FromDataMap(DataMap dMap)
        {
            Map map = new Map();
            map.Name = dMap.Name;
            map.Size = new Vector2D(dMap.SizeX, dMap.SizeY);
            foreach (DataMapCell dCell in dMap.CellList)
            {
                MapCell cell = MapCell.FromDataMapCell(dCell, map);
                map._cellList.Add(cell);
            }

            return map;
        }

        private Map() { }

        #endregion
    }
}
