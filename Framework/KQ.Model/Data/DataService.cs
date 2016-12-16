using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQ.Model
{
    /// <summary>
    /// 数据服务类
    /// 负责管理整个程序中使用的各种存盘数据
    /// </summary>
    public class DataService
    {
        public static DataService Instance { get; private set; }

        static DataService()
        {
            Instance = new DataService();
        }

        /// <summary>
        /// 地图数据集
        /// </summary>
        public MapDataset Maps { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        private DataService()
        {
            Maps = new MapDataset();
        }

        /// <summary>
        /// 将数据保存到本地文件
        /// </summary>
        public void SaveAll()
        {
            Maps.Save();
        }

        /// <summary>
        /// 从本地文件加载所有数据
        /// </summary>
        public void LoadAll()
        {
            Maps.Load();
        }
    }
}
