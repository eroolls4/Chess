using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }


        public Position(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public Player findSquareColor()
        {
            if ((this.Row + this.Column) % 2 == 0)
            {
                return Player.White;
            }
            return Player.Black;
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   Row == position.Row &&
                   Column == position.Column;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Column);
        }

        public static bool operator ==(Position left, Position right)
        {
            return EqualityComparer<Position>.Default.Equals(left, right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }


        public static Position operator +(Position position,Direction dir)
        {
            return new Position(position.Row + dir.rowDelta, position.Column + dir.colDelta);
        }
    }
}
