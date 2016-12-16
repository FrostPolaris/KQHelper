using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace KQ.Model.Data
{
    [Serializable]
    [XmlRoot(ElementName = "Block")]
    public class DataMapBlock
    {
        private const string nodeName = "Block";

        [XmlAttribute]
        public int PosX;

        [XmlAttribute]
        public int PosY;

        [XmlAttribute]
        public int SizeX;

        [XmlAttribute]
        public int SizeY;

        /// <summary>
        /// 单元格列表，这里只存储非默认数据的单元格
        /// </summary>
        [XmlArray]
        public List<DataMapCell> MapCellList = new List<DataMapCell>();

        public DataMapBlock()
        {
        }

        public DataMapBlock(MapBlock mapBlock)
        {
            this.PosX = mapBlock.Position.X;
            this.PosY = mapBlock.Position.Y;
            this.SizeX = mapBlock.Size.X;
            this.SizeY = mapBlock.Size.Y;
            foreach (MapCell cell in mapBlock.MapCellList)
            {
                DataMapCell dataCell = new DataMapCell(cell);
                if (!dataCell.CheckIsDefault())
                {
                    MapCellList.Add(dataCell);
                }
            }
        }

        /// <summary>
        /// 获取所有的单元格
        /// </summary>
        /// <returns>所有的单元格</returns>
        public List<DataMapCell> GetAllMapCell()
        {
            List<DataMapCell> nonDefaultList = MapCellList.ToList();
            List<DataMapCell> allCellList = new List<DataMapCell>();
            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    DataMapCell dCell = nonDefaultList.Find(c => c.PosX == x && c.PosY == y);
                    if (dCell != null)
                    {
                        allCellList.Add(dCell);
                        nonDefaultList.Remove(dCell);
                    }
                    else
                    {
                        dCell = DataMapCell.CreateDefault(x, y);
                        allCellList.Add(dCell);
                    }
                }
            }

            return allCellList;
        }



    }
}
