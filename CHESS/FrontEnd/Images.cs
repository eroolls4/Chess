using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Backend;

namespace FrontEnd
{
    class Images
    {

        private static readonly Dictionary<PIECE_TYPE, ImageSource> whiteSources = new()
        {
           { PIECE_TYPE.Pawn ,loadImage("Assets/PawnW.png")},
           { PIECE_TYPE.Rook ,loadImage("Assets/RookW.png")},
           { PIECE_TYPE.Knight ,loadImage("Assets/KnightW.png")},
           { PIECE_TYPE.Queen ,loadImage("Assets/QueenW.png")},
           { PIECE_TYPE.King ,loadImage("Assets/KingW.png")},
           { PIECE_TYPE.Bishop ,loadImage("Assets/BishopW.png")},
        };


        private static readonly Dictionary<PIECE_TYPE, ImageSource> blackSources = new()
        {
           { PIECE_TYPE.Pawn ,loadImage("Assets/PawnB.png")},
           { PIECE_TYPE.Rook ,loadImage("Assets/RookB.png")},
           { PIECE_TYPE.Knight ,loadImage("Assets/KnightB.png")},
           { PIECE_TYPE.Queen ,loadImage("Assets/QueenB.png")},
           { PIECE_TYPE.King ,loadImage("Assets/KingB.png")},
           { PIECE_TYPE.Bishop ,loadImage("Assets/BishopB.png")},
        };


        private static ImageSource loadImage(string path)
        {
            return new BitmapImage(new Uri(path, UriKind.Relative));
        }


        public static ImageSource GetImage(Player color, PIECE_TYPE type)
        {
            switch (color)
            {
                case Player.White:
                    return whiteSources[type];
                case Player.Black:
                    return blackSources[type];
                default:
                    return null;
            }
        }

        public static ImageSource GetImage(Piece piece)
        {
            if (piece == null)
            {
                return null;
            }
            return GetImage(piece.Color,piece.type);
        }
    }
}
