using Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DoublePawn : Moves
    {
        public override MOVE_TYPE MoveType => MOVE_TYPE.DoublePawn;

        public override Position fromPosition { get; }

        public override Position toPosition { get; }

        private readonly Position skipedPosition; //enpassant square

        public DoublePawn(Position fromPosition, Position toPosition)
        {
            this.fromPosition = fromPosition;
            this.toPosition = toPosition;
            skipedPosition = new Position((fromPosition.Row + toPosition.Row) / 2 , fromPosition.Column);
        }

        public override void Execute(Board board)
        {
            Player player = board[fromPosition].Color;
            board.setPlayerSkipPosition(player,skipedPosition);
            new NormalMove(fromPosition, toPosition).Execute(board);
        }
    }
}
