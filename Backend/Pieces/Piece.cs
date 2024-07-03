using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public abstract class Piece
    {

        public abstract PIECE_TYPE type { get; }
        public abstract Player Color { get; }
        public bool hasMoved { get; set; } = false;


        public abstract Piece Copy();


        public abstract IEnumerable<Moves> getAllMoves(Position from, Board board);

        //find all reachable positions on given direction

        protected IEnumerable<Position> MovePosInDir(Position from, Board board, Direction dir)
        {
            for (Position pos = from + dir; Board.isInside(pos); pos += dir)
            {

                if (board.isEmpty(pos))
                {
                    yield return pos;
                    continue;
                }

                Piece piece = board[pos];
                if (piece.Color != Color)
                {
                    yield return pos;

                }
                yield break;

            }
        }


        protected IEnumerable<Position> MovePosInDirs(Position from, Board board, Direction[] dirs)
        {
          return dirs.SelectMany(dir =>  MovePosInDir(from, board, dir));
        }
    }
}
