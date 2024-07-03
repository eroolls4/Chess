using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Pawn : Piece
    {
        public override PIECE_TYPE type => PIECE_TYPE.Pawn;

        public override Player Color { get; }


        private readonly Direction forward;

        public Pawn(Player color)
        {
            Color = color;

            if (color == Player.White)
            {
                forward = Direction.NORTH;
            }
            else if (color == Player.Black)
            {
                forward = Direction.SOUTH;

            }
        }


        public override Piece Copy()
        {
            Pawn copy = new Pawn(Color);
            copy.hasMoved = hasMoved;
            return copy;
        }


        private static bool canMoveTo(Position pos, Board board)
        {
            return Board.isInside(pos) && board.isEmpty(pos);
        }

        private bool canCaptureAt(Position pos, Board board)
        {
            if (!Board.isInside(pos) || board.isEmpty(pos))
            {
                return false;
            }
            return board[pos].Color != Color;
        }


        private IEnumerable<Moves> ForwardMoves(Position from, Board board)
        {
            Position oneMovePos = from + forward;

            if (canMoveTo(oneMovePos, board))
            {
                yield return new NormalMove(from, oneMovePos);

                Position twoMovePos = oneMovePos + forward;
                if (!hasMoved && canMoveTo(twoMovePos, board))
                {
                    yield return new NormalMove(from, twoMovePos);
                }

            }
        }

        private IEnumerable<Moves> DiagonalMoves(Position from, Board board)
        {
            foreach (Direction dir in new Direction[] { Direction.WEST, Direction.EAST })
            {
                Position to = from + dir + forward;
                if (canCaptureAt(to, board))
                {
                    yield return new NormalMove(from, to);
                }
            }

        }

        public override IEnumerable<Moves> getAllMoves(Position from, Board board)
        {
           return ForwardMoves(from, board).Concat(DiagonalMoves(from,board));
        }
    }
}
