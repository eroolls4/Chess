using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Result
    {
        public Player Winner { get; }
        public END_GAME_REASONS Reason { get; }

        public Result(Player winner, END_GAME_REASONS reasont)
        {
            Winner = winner;
            Reason = reasont;
        }

        public static Result Win(Player winner)
        {
            return new Result(winner, END_GAME_REASONS.Checkmate);
        }

        public static Result Draw(END_GAME_REASONS reason)
        {
            return new Result(Player.None,reason);
        }
    }
}
