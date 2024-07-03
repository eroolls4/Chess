using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Rook : Piece
    {
        private static readonly Direction[] legalMovesForRook = new Direction[]
      {
            Direction.NORTH,
            Direction.EAST,
            Direction.WEST,
            Direction.SOUTH
      };


        public override PIECE_TYPE type => PIECE_TYPE.Rook;

        public override Player Color { get; }


       

        public Rook(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Rook copy = new Rook(Color);
            copy.hasMoved = hasMoved;
            return copy;
        }

        public override IEnumerable<Moves> getAllMoves(Position from, Board board)
        {
                                      //all reachable moves               //move to a particular pos
            return MovePosInDirs(from, board, legalMovesForRook).Select(to => new NormalMove(from, to));
        }
    }
}
