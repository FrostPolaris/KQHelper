using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQ.Model
{
    /// <summary>
    /// 数据集接口
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    public interface IDataset<T>
    {
        /// <summary>
        /// 全部数据
        /// </summary>
        IReadOnlyList<T> AllData { get; }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="data">需要添加的数据</param>
        void Add(T data);

        /// <summary>
        /// 移除数据
        /// </summary>
        /// <param name="data">需要移除的数据</param>
        void Remove(T data);

        /// <summary>
        /// 保存到本地文件
        /// </summary>
        void Save();

        /// <summary>
        /// 从本地文件加载
        /// </summary>
        void Load();
    }
}
