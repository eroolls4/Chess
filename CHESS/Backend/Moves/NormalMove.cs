﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class NormalMove : Moves
    {
        public override MOVE_TYPE MoveType => MOVE_TYPE.Normal;

        public override Position fromPosition { get; }

        public override Position toPosition { get; }

        public NormalMove(Position fromPosition, Position toPosition)
        {
            this.fromPosition = fromPosition;
            this.toPosition = toPosition;
        }

        public override void Execute(Board board)
        {
            Piece piece = board[fromPosition];
            board[toPosition] = piece;
            board[fromPosition] = null;
            piece.hasMoved = true;
        }
    }
}
