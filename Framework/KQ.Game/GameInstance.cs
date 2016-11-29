using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KQ.Model;

namespace KQ.Game
{
    public class GameInstance : NotificationObject
    {
        /// <summary>
        /// 地图列表
        /// </summary>
        public IReadOnlyList<Map> MapList
        {
            get { return mapList; }
        }
        private List<Map> mapList = new List<Map>();

        /// <summary>
        /// 当前地图
        /// </summary>
        public Map CurrentMap
        {
            get
            {
                if (MapList.Count > 0)
                    return MapList[0];
                return emptyMap;
            }
        }
        private static Map emptyMap = new Map("空地图");

        /// <summary>
        /// 构造函数
        /// </summary>
        public GameInstance()
        {
            InitWithTestMap();
        }

        /// <summary>
        /// 添加地图
        /// </summary>
        /// <param name="newMap">新的地图</param>
        public void AddMap(Map newMap)
        {
            mapList.Add(newMap);
            RaisePropertyChanged("MapList");
            RaisePropertyChanged("CurrentMap");
        }

        /// <summary>
        /// 使用测试地图进行初始化
        /// </summary>
        private void InitWithTestMap()
        {
            Map testMap = new Map("测试地图");
            testMap.AddBlock(new MapBlock(0, 0, 8, 8));
            testMap.AddBlock(new MapBlock(0, 8, 8, 8));
            testMap.AddBlock(new MapBlock(8, 0, 8, 8));
            testMap.AddBlock(new MapBlock(8, 8, 8, 8));

            mapList.Add(testMap);
        }
    }
}
