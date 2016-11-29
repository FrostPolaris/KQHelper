using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQ.Model
{
    public struct Vector2D
    {
        public int X { get; private set; }
        public int Y { get; private set; }

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

        public static Vector2D GetOrigin()
        {
            return new Vector2D(0, 0);
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

        public override string ToString()
        {
            return string.Format("{0}, {1}", X, Y);
        }
    }
}
