using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public abstract class Moves
    {
        public abstract MOVE_TYPE MoveType { get; }

        public abstract Position fromPosition { get; }
        public abstract Position toPosition { get; }


        public abstract void Execute(Board board);

        public virtual bool isLegal(Board board)
        {
            //if executing this move doesnt leave  king in check

            Player player = board[fromPosition].Color;

            Board copied=board.Copy();
            Execute(copied);
            return !copied.IsInCheck(player);
        }
    }
}
