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
    }
}
