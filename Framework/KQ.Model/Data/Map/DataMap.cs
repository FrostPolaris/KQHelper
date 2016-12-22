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

        [XmlArray]
        public List<DataMapCell> CellList = new List<DataMapCell>();

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
                CellList.Add(new DataMapCell(cell));
            }
        }

    }
}
