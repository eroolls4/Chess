using Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EnPassant : Moves
    {
        public override MOVE_TYPE MoveType => MOVE_TYPE.EnPassant;
        
        public override Position fromPosition { get; }
        public override Position toPosition { get; }

        private readonly Position capturedPawnPos;

        public EnPassant(Position fromPosition, Position toPosition)
        {
            this.fromPosition = fromPosition;
            this.toPosition = toPosition;
            this.capturedPawnPos = new Position(fromPosition.Row,toPosition.Column);
        }

        public override void Execute(Board board)
        {
            new NormalMove(fromPosition, toPosition).Execute(board);
            board[capturedPawnPos] = null;
        }
    }
}
