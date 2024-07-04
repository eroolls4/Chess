using Service;
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

        private static bool isUnMovedRook(Position pos, Board board)
        {
            if (board.isEmpty(pos)) return false;

            Piece piece = board[pos];
            return piece.type == PIECE_TYPE.Rook && !piece.hasMoved;
        }


        private static bool AllEmpty(IEnumerable<Position> positions,Board board)
        {
            return positions.All(pos => board.isEmpty(pos));
        }


        private bool canCastleKingSide(Position from, Board board)
        {
            if (hasMoved) return false;

            Position rookPos = new Position(from.Row, 7);
            Position[] betweenPositions = new Position[] { new(from.Row, 5), new(from.Row, 6) };

            return isUnMovedRook(rookPos, board) && AllEmpty(betweenPositions, board);
        }

        private bool canCastleQueenSide(Position from, Board board)
        {
            if (hasMoved) return false;

            Position rookPos = new Position(from.Row, 7);
            Position[] betweenPositions = new Position[] { new(from.Row, 1), new(from.Row, 2) , new(from.Row,3) };

            return isUnMovedRook(rookPos, board) && AllEmpty(betweenPositions, board);

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

            if (canCastleKingSide(from, board))
            {
                yield return new Castle(MOVE_TYPE.CastleKS, from);
            }

            if (canCastleQueenSide(from, board))
            {
                yield return new Castle(MOVE_TYPE.CastleQS, from);
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
