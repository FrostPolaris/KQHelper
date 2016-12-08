using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQ.Model
{
    /// <summary>
    /// 地形类型
    /// </summary>
    public enum ETerrianType
    {
        /// <summary>
        /// 普通地形
        /// </summary>
        Normal,

        /// <summary>
        /// 阻断地形（障碍物）
        /// </summary>
        Blocked,

        /// <summary>
        /// 水域地形
        /// </summary>
        Water,

        /// <summary>
        /// 传送点
        /// </summary>
        Teleport,
    }
}
