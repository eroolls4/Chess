using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Direction
    {
        public readonly static Direction NORTH = new Direction(-1,0);
        public readonly static Direction SOUTH = new Direction(1, 0);
        public readonly static Direction EAST = new Direction(0, 1);
        public readonly static Direction WEST = new Direction(0, -1);

        public readonly static Direction NORTHEAST = NORTH + EAST;
        public readonly static Direction NORTHWEST = NORTH + WEST;
        public readonly static Direction SOUTHEAST = SOUTH + EAST;
        public readonly static Direction SOUTHWEST = SOUTH + WEST;


        public int rowDelta { get; }
        public int colDelta { get; }

        public Direction(int rowDelta, int colDelta)
        {
            this.rowDelta = rowDelta;
            this.colDelta = colDelta;
        }

        public static Direction operator +(Direction dir1, Direction dir2)
        {
            return new Direction(dir1.rowDelta + dir2.rowDelta, dir1.colDelta + dir2.colDelta);
        }

        public static Direction operator *(int scalar, Direction dir)
        {
            return new Direction(scalar * dir.rowDelta,scalar * dir.colDelta); 
        }
    }
}
