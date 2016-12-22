using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using KQ.Basic;
using KQ.Model.Data;

namespace KQ.Model
{
    public class MapDataset : IDataset<Map>
    {
        private static readonly string filePath;

        static MapDataset()
        {
            filePath = Path.Combine(AppConfig.DataDir, "MapData.xml");
        }

        public IReadOnlyList<Map> AllData
        {
            get { return _allData; }
        }
        private List<Map> _allData = new List<Map>();

        public void Add(Map data)
        {
            _allData.Add(data);
        }

        public void Remove(Map data)
        {
            _allData.Remove(data);
        }

        public void Save()
        {
            List<DataMap> mapList = new List<DataMap>();
            foreach (Map map in AllData)
            {
                mapList.Add(new DataMap(map));
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(mapList.GetType());
                serializer.Serialize(fs, mapList);
            }
        }

        public void Load()
        {
            _allData.Clear();
            
            if (!File.Exists(filePath))
            {
                return;
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<DataMap>));
                List<DataMap> dataMapList = serializer.Deserialize(fs) as List<DataMap>;
                foreach (DataMap dataMap in dataMapList)
                {
                    _allData.Add(Map.FromDataMap(dataMap));
                }
            }
        }
    }
}
