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

        [XmlArray]
        public List<DataMapBlock> BlockList = new List<DataMapBlock>();

        public DataMap()
        {
        }

        public DataMap(Map map)
        {
            this.Name = map.Name;
            foreach (MapBlock block in map.BlockList)
            {
                BlockList.Add(new DataMapBlock(block));
            }
        }

    }
}
