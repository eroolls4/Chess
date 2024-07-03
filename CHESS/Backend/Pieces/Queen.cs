using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Queen : Piece
    {

        private static readonly Direction[] legalMovesForQueen = new Direction[]
  {
            Direction.NORTH,
            Direction.EAST,
            Direction.WEST,
            Direction.SOUTH,

            Direction.NORTHWEST,
            Direction.NORTHEAST,
            Direction.SOUTHWEST,
            Direction.SOUTHEAST
  };

        public override PIECE_TYPE type => PIECE_TYPE.Queen;

        public override Player Color { get; }

        public Queen(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Queen copy = new Queen(Color);
            copy.hasMoved = hasMoved;

            return copy;
        }


        public override IEnumerable<Moves> getAllMoves(Position from, Board board)
        {
                             //all reachable moves               //move to a particular pos
            return MovePosInDirs(from, board, legalMovesForQueen).Select(to => new NormalMove(from, to));
        }
    }
}
