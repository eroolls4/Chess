using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Bishop : Piece
    {
        private static readonly Direction[] dirsInDiagonal = new Direction[]
        {
            Direction.NORTHWEST,
            Direction.NORTHEAST,
            Direction.SOUTHWEST,
            Direction.SOUTHEAST
        }; 

        public override PIECE_TYPE type => PIECE_TYPE.Bishop;

        public override Player Color { get; }

        public Bishop(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Bishop copy = new Bishop(Color);
            copy.hasMoved = hasMoved;
            return copy;
        }

        public override IEnumerable<Moves> getAllMoves(Position from, Board board)
        {
                                 //all reachable moves               //move to a particular pos
          return MovePosInDirs(from, board,dirsInDiagonal).Select(to => new NormalMove(from, to));
        }
    }
}
