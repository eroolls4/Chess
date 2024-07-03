using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class King : Piece
    {
        private static readonly Direction[] legalMovesForKing = new Direction[]
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

        public override PIECE_TYPE type => PIECE_TYPE.King;

        public override Player Color { get; }

        public King(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            King copy = new King(Color);
            copy.hasMoved = hasMoved;
            return copy;
        }


        private IEnumerable<Position> AllowedMovePositions(Position from, Board board)
        {
            foreach (Direction direction in legalMovesForKing)
            {
                Position to = from + direction;
                if (!Board.isInside(to))
                {
                    continue;
                }
                if (board.isEmpty(to) || board[to].Color != Color)
                {
                    yield return to;
                }
            }

        }

        public override IEnumerable<Moves> getAllMoves(Position from, Board board)
        {
            foreach (Position to in AllowedMovePositions(from, board))
            {
                yield return new NormalMove(from, to);
            }
        }

        public override bool CanCaptureOpponentKing(Position from, Board board)
        {
            return AllowedMovePositions(from, board).Any(to =>
            {
                Piece piece = board[to];
                return piece != null && piece.type == PIECE_TYPE.King;
            });
        }
    }
}
