using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQ.Model
{
    /// <summary>
    /// 地图尺寸类
    /// </summary>
    public sealed class MSize
    {
        /// <summary>
        /// 宽度
        /// </summary>
        public int Width
        {
            get { return _width; }
            private set
            {
                _width = value;
                if (_width < 0)
                    _width = 0;
            }
        }
        private int _width = 0;

        /// <summary>
        /// 高度
        /// </summary>
        public int Height
        {
            get { return _height; }
            private set
            {
                _height = value;
                if (_height < 0)
                    _height = 0;
            }
        }
        private int _height = 0;

        /// <summary>
        /// 是否为有效的尺寸
        /// 尺寸面积大于0时为有效
        /// </summary>
        public bool IsValid
        {
            get
            {
                return GetArea() > 0;
            }
        }

        public MSize()
        {
            Width = Height = 0;
        }

        public MSize(int InWidth, int InHeight)
        {
            Width = InWidth;
            Height = InHeight;
        }

        /// <summary>
        /// 获取面积
        /// </summary>
        /// <returns>对应的面积</returns>
        public int GetArea()
        {
            return Width * Height;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Width, Height);
        }
    }
}
