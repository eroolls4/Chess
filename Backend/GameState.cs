using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class GameState
    {
        public Board board { get; }

        public Player CurrentPlayer { get; private set; }

        public GameState(Board board, Player currentPlayer)
        {
            this.board = board;
            CurrentPlayer = currentPlayer;
        }


        public IEnumerable<Moves> LegalMovesForPiece(Position position)  //we need pos since a piece have no idea for its position
        {
            if (board.isEmpty(position) || board[position].Color != CurrentPlayer)
            {
                return Enumerable.Empty<Moves>();
            }

            Piece piece = board[position];

            IEnumerable<Moves> canidateMoves = piece.getAllMoves(position, board);
            return canidateMoves.Where(move => move.isLegal(board));
        }


        public void makeMove(Moves move)
        {
            move.Execute(board);
            CurrentPlayer = CurrentPlayer.findOpponent();
        }
    }
}
