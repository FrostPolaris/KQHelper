using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KQ.Model
{
    [Serializable]
    [XmlRootAttribute(ElementName = "Vector")]
    public struct Vector2D
    {
        [XmlAttribute]
        public int X { get; set; }

        [XmlAttribute]
        public int Y { get; set; }

        public Vector2D(int inX, int inY)
        {
            X = inX;
            Y = inY;
        }

        public static Vector2D operator +(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2D operator -(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.X - b.X, a.Y - b.Y);
        }

        /// <summary>
        /// 获取原点Vector2D
        /// </summary>
        /// <returns>原点Vector2D</returns>
        public static Vector2D GetOrigin()
        {
            return new Vector2D(0, 0);
        }

        /// <summary>
        /// 判断当前的Vector2D是否能表示一个合法的尺寸
        /// </summary>
        /// <returns>当前对象是否能表示一个合法的尺寸</returns>
        public bool IsValidSize()
        {
            return X >= 0 && Y >= 0;
        }

        public override bool Equals(object obj)
        {
            Vector2D? other = obj as Vector2D?;
            if (other == null)
            {
                return false;
            }

            return (this.X == other.Value.X && this.Y == other.Value.Y);
        }

        public override int GetHashCode()
        {
            int tempInt = X + (Y << 16);
            return tempInt.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", X, Y);
        }

        /// <summary>
        /// 从字符串转换成Vector2D对象
        /// </summary>
        /// <param name="dataString">包含了数据信息的字符串</param>
        /// <returns>根据字符串转换出来的Vector2D对象，转换失败时返回空</returns>
        public static Vector2D? FromString(string dataString)
        {
            if(string.IsNullOrWhiteSpace(dataString))
            {
                return null;
            }

            string[] strArray = dataString.Replace(" ", "").Split(',');
            if (strArray.Length != 2)
            {
                return null;
            }

            int x, y;
            if (!int.TryParse(strArray[0], out x) || !int.TryParse(strArray[1], out y))
            {
                return null;
            }
            else
            {
                return new Vector2D(x, y);
            }
        }
    }
}
