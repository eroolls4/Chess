using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Board
    {
        private readonly Piece[,] pieces = new Piece[8, 8];

        private readonly Dictionary<Player,Position> pawnSkipPositions=new Dictionary<Player, Position>()
        {
            { Player.White, null },
            { Player.Black, null}
        };

        public Piece this[int row, int col]
        {
            get { return pieces[row, col]; }
            set { pieces[row, col] = value; }
        }


        public Position getPlayerSkipPosition(Player player)
        {
            return pawnSkipPositions[player];
        }

        public void setPlayerSkipPosition(Player player,Position position)
        {
            pawnSkipPositions[player] = position;
        }

        public Piece this[Position position]
        {
            get { return pieces[position.Row, position.Column]; }
            set { pieces[position.Row, position.Column] = value; }
        }

        public static Board Init()
        {
            Board board = new Board();
            board.addPieces();
            return board;
        }

        private void addPieces()
        {
            this[0, 0] = new Rook(Player.Black);
            this[0, 1] = new Knight(Player.Black);
            this[0, 2] = new Bishop(Player.Black);
            this[0, 3] = new Queen(Player.Black);
            this[0, 4] = new King(Player.Black);
            this[0, 5] = new Bishop(Player.Black);
            this[0, 6] = new Knight(Player.Black);
            this[0, 7] = new Rook(Player.Black);

            this[7, 0] = new Rook(Player.White);
            this[7, 1] = new Knight(Player.White);
            this[7, 2] = new Bishop(Player.White);
            this[7, 3] = new Queen(Player.White);
            this[7, 4] = new King(Player.White);
            this[7, 5] = new Bishop(Player.White);
            this[7, 6] = new Knight(Player.White);
            this[7, 7] = new Rook(Player.White);


            for (int c = 0; c < 8; c++)
            {
                this[1, c] = new Pawn(Player.Black);
                this[6, c] = new Pawn(Player.White);
            }
        }


        public static bool isInside(Position pos)
        {
            return pos.Row >= 0 && pos.Row < 8 && pos.Column >= 0 && pos.Column < 8;
        }

        public bool isEmpty(Position pos)
        {
            return this[pos] == null;
        }


        public IEnumerable<Position> NonEmptyPositions()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Position position = new Position(i, j);

                    if (!isEmpty(position))
                    {
                        yield return position;
                    }
                }
            }
        }

        public IEnumerable<Position> NonEmptyPositionsFor(Player player)
        {
            return NonEmptyPositions().Where(pos => this[pos].Color == player);
        }


        public bool IsInCheck(Player player)
        {
            return NonEmptyPositionsFor(player.findOpponent()).Any(pos =>
            {
                Piece piece = this[pos];
                return piece.CanCaptureOpponentKing(pos, this);
            });
        }

        public Board Copy()
        {
            Board copy=new Board();

            foreach (Position pos in NonEmptyPositions())
            {
                copy[pos] = this[pos].Copy();
            }
            return copy;
        }
    }
}
