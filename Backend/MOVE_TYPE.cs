using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public enum MOVE_TYPE
    {
        Normal,

        //special moves
        CastleKS,
        CastleQS,
        DoublePawn,
        EnPassant,
        PawnPromotion
    }
}
