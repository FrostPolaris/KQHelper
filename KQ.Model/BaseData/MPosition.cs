using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQ.Model
{
    /// <summary>
    /// 地图位置类
    /// </summary>
    public sealed class MPosition
    {
        /// <summary>
        /// X坐标
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y坐标
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public MPosition()
        {
            X = Y = 0;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="inX">X坐标</param>
        /// <param name="inY">Y坐标</param>
        public MPosition(int inX, int inY)
        {
            X = inX;
            Y = inY;
        }
    }
}
