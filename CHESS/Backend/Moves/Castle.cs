using Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Castle : Moves
    {
        public override MOVE_TYPE MoveType { get; }

        //for king
        public override Position fromPosition { get; }
        public override Position toPosition { get; }


        private readonly Direction kingMoveDir;

        private readonly Position rookFromPosition;
        private readonly Position rookToPosition;

        public Castle(MOVE_TYPE moveType, Position kingPosition)
        {
            MoveType = moveType;
            this.fromPosition = kingPosition;

            if(moveType == MOVE_TYPE.CastleKS)
            {
                kingMoveDir = Direction.EAST;
                toPosition = new Position(kingPosition.Row, 6);
                rookFromPosition = new Position(kingPosition.Row, 7);
                rookToPosition = new Position(kingPosition.Row, 5);
            }else if(moveType == MOVE_TYPE.CastleQS)
            {
                kingMoveDir = Direction.WEST;
                toPosition = new Position(kingPosition.Row, 2);
                rookFromPosition = new Position(kingPosition.Row, 0);
                rookToPosition = new Position(kingPosition.Row, 3);
            }
        }

        public override void Execute(Board board)
        {
            //new NormalMove(fromPosition, toPosition).Execute(board);
            new NormalMove(rookFromPosition,rookToPosition).Execute(board);
        }

        public override bool isLegal(Board board)
        {
            Player player = board[fromPosition].Color; //get king color

            if (board.IsInCheck(player)) return false;
            Board copied = board.Copy();

            Position kingPositionInCopy = fromPosition;

            for (int i = 0; i < 2; i++)
            {
                new NormalMove(kingPositionInCopy, kingPositionInCopy + kingMoveDir).Execute(board);
                kingPositionInCopy += kingMoveDir;

                if (copied.IsInCheck(player)) return false;
            }
            return true;
        }
    }
}
