using Backend;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly Image[,] pieceImages = new Image[8, 8];
        private readonly Rectangle[,] highlights = new Rectangle[8, 8];


        private readonly Dictionary<Position, Moves> moveCache = new Dictionary<Position, Moves>();


        private GameState gameState;
        private Position selectedPos = null;

        public MainWindow()
        {
            InitializeComponent();
            initializeBoard();

            gameState = new GameState(Board.Init(), Player.White);
            drawBoard(gameState.board);
            setCursor(gameState.CurrentPlayer);
        }


        private void initializeBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Image image = new Image();
                    pieceImages[i, j] = image;
                    PieceGrid.Children.Add(image);

                    Rectangle highlight = new Rectangle();
                    highlights[i, j] = highlight;
                    HighlightGrid.Children.Add(highlight);
                }
            }
        }

        private void drawBoard(Board board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Piece piece = board[i, j];
                    pieceImages[i, j].Source = Images.GetImage(piece);
                }
            }
        }

        private void BoardGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isMenuOnScreen())
            {
                return;
            }

            Point point = e.GetPosition(BoardGrid); //point relative to boardGrid
            Position pos = ToSquarePosition(point);

            if (selectedPos == null)
            {
                OnFromPositionSelected(pos);
            }
            else
            {
                OnToPositionSelected(pos);
            }
        }

        private void OnToPositionSelected(Position pos)  // a piece is selected
        {
            selectedPos = null;
            HideHighlights();

            if (moveCache.TryGetValue(pos, out Moves move))
            {
                HandleMove(move);
            }
        }

        private void HandleMove(Moves move)
        {
            gameState.makeMove(move);
            drawBoard(gameState.board);
            setCursor(gameState.CurrentPlayer);


            if (gameState.isGameOver())
            {
                showGameOver(); 
            }
        }

        private void OnFromPositionSelected(Position pos)
        {
            IEnumerable<Moves> allowedMoves = gameState.LegalMovesForPiece(pos);
            if (allowedMoves.Any())
            {
                selectedPos = pos;
                CacheMoves(allowedMoves);
                ShowHighlights();
            }

        }

        private Position ToSquarePosition(Point point)
        {
            double squareSize = BoardGrid.ActualWidth / 8;

            int row = (int)(point.Y / squareSize);
            int col = (int)(point.X / squareSize);

            return new Position(row, col);
        }


        private void CacheMoves(IEnumerable<Moves> llegalMovesForSelectedPiece)
        {
            moveCache.Clear();

            foreach (Moves move in llegalMovesForSelectedPiece)
            {
                moveCache[move.toPosition] = move;
            }
        }


        private void ShowHighlights()
        {
            Color color = Color.FromArgb(150, 125, 255, 125);
            foreach (Position to in moveCache.Keys)
            {
                highlights[to.Row, to.Column].Fill = new SolidColorBrush(color);
            }
        }


        private void HideHighlights()
        {

            foreach (Position to in moveCache.Keys)
            {
                highlights[to.Row, to.Column].Fill = Brushes.Transparent;
            }
        }


        private void setCursor(Player player)
        {
            if (player == Player.White)
            {
                Cursor = ChessCursors.whiteCursor;
            }
            else if (player == Player.Black)
            {
                Cursor = ChessCursors.blackCursor;
            }
        }

        private bool isMenuOnScreen()
        {
            return MenuContainer.Content != null;
        }

        private void showGameOver()
        {
            GameOverMenu gameOverMenu = new GameOverMenu(gameState);
            MenuContainer.Content = gameOverMenu;

            gameOverMenu.optionSelected += option =>
            {
                if (option == OPTION.RESTART)
                {
                    MenuContainer.Content = null;
                    RestartGame();
                }
                else
                {
                    Application.Current.Shutdown();
                }
            };
        }

        private void RestartGame()
        {
            HideHighlights();
            moveCache.Clear();
            gameState = new GameState(Board.Init(), Player.White);
            drawBoard(gameState.board);
            setCursor(gameState.CurrentPlayer);
        }
    }
}