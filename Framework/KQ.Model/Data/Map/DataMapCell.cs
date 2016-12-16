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
    [XmlRoot(ElementName = "Cell")]
    public class DataMapCell
    {
        [XmlAttribute]
        public int PosX;

        [XmlAttribute]
        public int PosY;

        [XmlAttribute]
        public ETerrianType TerrianType;

        public DataMapCell()
        {
        }

        public DataMapCell(MapCell mapCell)
        {
            this.PosX = mapCell.Position.X;
            this.PosY = mapCell.Position.Y;
            this.TerrianType = mapCell.TerrianType;
        }

        /// <summary>
        /// 检测是否为默认数据
        /// 默认数据不参与序列化
        /// </summary>
        /// <returns></returns>
        public bool CheckIsDefault()
        {
            return TerrianType == ETerrianType.Normal;
        }

        /// <summary>
        /// 创建一个默认数据的单元格
        /// </summary>
        /// <param name="x">位置的X坐标</param>
        /// <param name="y">位置的Y坐标</param>
        /// <returns></returns>
        public static DataMapCell CreateDefault(int x, int y)
        {
            DataMapCell dCell = new DataMapCell();
            dCell.PosX = x;
            dCell.PosY = y;
            return dCell;
        }

    }
}
