using Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PawnPromotion : Moves
    {
        public override MOVE_TYPE MoveType => MOVE_TYPE.PawnPromotion;

        public override Position fromPosition { get; }

        public override Position toPosition { get; }

        private readonly PIECE_TYPE newType;

        public PawnPromotion(Position fromPosition, Position toPosition, PIECE_TYPE newType)
        {
            this.fromPosition = fromPosition;
            this.toPosition = toPosition;
            this.newType = newType;
        }

        private Piece CreatePawnPromototionPiece(Player color)
        {
            switch (newType)
            {
                case PIECE_TYPE.Bishop:
                    return new Bishop(color);
                case PIECE_TYPE.Knight:
                    return new Knight(color);
                case PIECE_TYPE.Rook:
                    return new Rook(color);
                default:
                    return new Queen(color);
            }

        }


        public override void Execute(Board board)
        {
            Piece pawn = board[fromPosition];
            board[fromPosition] = null;

            Piece promototionPiece=CreatePawnPromototionPiece(pawn.Color);
            promototionPiece.hasMoved = true;
            board[toPosition] = promototionPiece;
        }

        public override bool isLegal(Board board)
        {
            return base.isLegal(board);
        }
    }
}
