using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Knight : Piece
    {
        public override PIECE_TYPE type => PIECE_TYPE.Knight;

        public override Player Color { get; }

        public Knight(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Knight copy = new Knight(Color);
            copy.hasMoved = hasMoved;
            return copy;
        }

        private static IEnumerable<Position> PotentialToPositions(Position from)
        {
            foreach (Direction verticalDirs in new Direction[] { Direction.NORTH, Direction.SOUTH })
            {
                foreach (Direction horizontalDirs in new Direction[] { Direction.EAST, Direction.WEST })
                {
                    yield return from + 2 * verticalDirs + horizontalDirs;
                    yield return from + 2 * horizontalDirs + verticalDirs;
                }
            }
        }



        private IEnumerable<Position> AllowedMovePositions(Position from, Board board)
        {
            return PotentialToPositions(from).Where(pos => Board.isInside(pos) &&
                   (board.isEmpty(pos) || board[pos].Color != Color));

        }

        public override IEnumerable<Moves> getAllMoves(Position from, Board board)
        {
            return AllowedMovePositions(from,board).Select(to => new NormalMove(from,to));
        }
    }
}
