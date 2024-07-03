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

        public Result result { get; private set; } = null;

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
            CheckForGameOver();
        }


        public IEnumerable<Moves> AllLegalMovesForPlayer(Player player)
        {
            IEnumerable<Moves> candidateMoves = board.NonEmptyPositionsFor(player).SelectMany(pos =>
            {
                Piece piece = board[pos];
                return piece.getAllMoves(pos, board);
            });

            return candidateMoves.Where(move => move.isLegal(board));
        }

        private void CheckForGameOver()
        {
            if (!AllLegalMovesForPlayer(CurrentPlayer).Any())
            {
                if (board.IsInCheck(CurrentPlayer))
                {
                    this.result = Result.Win(CurrentPlayer.findOpponent());
                }
                else
                {
                    this.result = Result.Draw(END_GAME_REASONS.Stealmate);
                }
            }

        }

        public bool isGameOver()
        {
            return result != null;
        }
    }
}
