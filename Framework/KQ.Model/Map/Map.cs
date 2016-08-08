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
        /// 地图位置，按所有区块的包围盒的坐标进行计算
        /// </summary>
        public MPosition Position { get; private set; }

        /// <summary>
        /// 地图尺寸，按所有区块的包围盒的尺寸进行计算
        /// </summary>
        public MSize Size { get; private set; }

        /// <summary>
        /// 区块列表
        /// </summary>
        public IReadOnlyList<MapBlock> RegionList
        {
            get { return blockList; }
        }
        private List<MapBlock> blockList = new List<MapBlock>();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">地图名称</param>
        public Map(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// 添加新的区块
        /// </summary>
        /// <param name="newRegion">新的区块</param>
        /// <returns>是否成功添加</returns>
        public bool AddRegion(MapBlock newRegion)
        {
            if (!newRegion.Size.IsValid)
                return false;

            //如果新的区块和已有区块重合，则不添加
            foreach(MapBlock region in blockList)
            {
                if (region.CheckIsOverlapped(newRegion))
                    return false;
            }

            newRegion.ParentMap = this;
            blockList.Add(newRegion);
            RefreshPositionAndSize();

            return true;
        }

        /// <summary>
        /// 刷新位置和尺寸
        /// </summary>
        private void RefreshPositionAndSize()
        {
            if (blockList.Count == 0)
            {
                Position = new MPosition();
                Size = new MSize();
                return;
            }

            int minX = blockList[0].MinX;
            int minY = blockList[0].MinY;
            int maxX = blockList[0].MaxX;
            int maxY = blockList[0].MaxY;
            foreach (MapBlock block in blockList)
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

            Position = new MPosition(minX, minY);
            Size = new MSize((maxX - minX), (maxY - minY));
        }
    }
}
