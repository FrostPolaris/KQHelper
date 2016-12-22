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
    [XmlRoot(ElementName = "Map")]
    public class DataMap
    {
        [XmlAttribute]
        public string Name;

        [XmlAttribute]
        public int SizeX;

        [XmlAttribute]
        public int SizeY;

        /// <summary>
        /// 这里只保存非默认值的单元格
        /// </summary>
        [XmlArray]
        public List<DataMapCell> NonDefaultCellList = new List<DataMapCell>();

        public DataMap()
        {
        }

        public DataMap(Map map)
        {
            this.Name = map.Name;
            this.SizeX = map.Size.X;
            this.SizeY = map.Size.Y;

            foreach (MapCell cell in map.CellList)
            {
                DataMapCell dCell = new DataMapCell(cell);
                if (!dCell.CheckIsDefault())
                {
                    NonDefaultCellList.Add(dCell);
                }
            }
        }

        /// <summary>
        /// 获取完整的单元格列表
        /// </summary>
        /// <returns>完整的单元格列表</returns>
        public List<DataMapCell> GetCellList()
        {
            List<DataMapCell> cellList = new List<DataMapCell>();
            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    DataMapCell dCell = NonDefaultCellList.Find(c => c.PosX == x && c.PosY == y);
                    if (dCell == null)
                    {
                        dCell = new DataMapCell();
                        dCell.PosX = x;
                        dCell.PosY = y;
                    }
                    cellList.Add(dCell);
                }
            }

            return cellList;
        }
    }
}
