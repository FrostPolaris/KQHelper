using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// 地图位置，取所有区块包围盒的左上角单元格坐标（该单元格可能并不存在）
        /// </summary>
        public Vector2D Position { get; private set; }

        /// <summary>
        /// 地图尺寸，取所有区块包围盒的尺寸
        /// </summary>
        public Vector2D Size { get; private set; }

        /// <summary>
        /// 区块列表
        /// </summary>
        public IReadOnlyList<MapBlock> BlockList
        {
            get { return _blockList; }
        }
        private List<MapBlock> _blockList = new List<MapBlock>();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">地图名称</param>
        public Map(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// 扩展区块
        /// </summary>
        /// <param name="x">区块位置的X坐标</param>
        /// <param name="y">区块位置的Y坐标</param>
        /// <param name="w">区块的宽度</param>
        /// <param name="h">区块的高度</param>
        /// <returns>是否扩展成功</returns>
        public bool AppendBlock(int x, int y, int w, int h)
        {
            return AppendBlock(new Vector2D(x, y), new Vector2D(w, h));
        }

        /// <summary>
        /// 扩展区块
        /// </summary>
        /// <param name="position">区块的位置</param>
        /// <param name="size">区块的尺寸</param>
        /// <returns>是否扩展成功</returns>
        public bool AppendBlock(Vector2D position, Vector2D size)
        {
            MapBlock newBlock = new MapBlock(this, position, size);

            //如果新的区块和已有区块重合，则不添加
            foreach (MapBlock block in _blockList)
            {
                if (block.CheckIsOverlapped(newBlock))
                    return false;
            }

            _blockList.Add(newBlock);
            RefreshPositionAndSize();
            return true;
        }

        /// <summary>
        /// 刷新位置和尺寸
        /// </summary>
        private void RefreshPositionAndSize()
        {
            if (_blockList.Count == 0)
            {
                Position = Vector2D.GetOrigin();
                Size = Vector2D.GetOrigin();
                return;
            }

            int minX = _blockList[0].MinX;
            int minY = _blockList[0].MinY;
            int maxX = _blockList[0].MaxX;
            int maxY = _blockList[0].MaxY;
            foreach (MapBlock block in _blockList)
            {
                if (block.MinX < minX)
                    minX = block.MinX;
                if (block.MinY < minY)
                    minY = block.MinY;
                if (block.MaxX > maxX)
                    maxX = block.MaxX;
                if (block.MaxY > maxY)
                    maxY = block.MaxY;
            }

            Position = new Vector2D(minX, minY);
            Size = new Vector2D((maxX - minX + 1), (maxY - minY + 1));
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("名称：{0}", Name));
            sb.Append(string.Format("  坐标：（{0}）", Position));
            sb.Append(string.Format("  尺寸：({0})", Size));
            sb.Append(string.Format("  区块数量：{0}", _blockList.Count));

            return sb.ToString();
        }
    }
}
