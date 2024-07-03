using Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for GameOverMenu.xaml
    /// </summary>
    public partial class GameOverMenu : UserControl
    {

        public event Action<OPTION> optionSelected; //main window registers event handler for this event
        public GameOverMenu(GameState gameState)
        {
            InitializeComponent();

            Result result = gameState.result;
            WinnerText.Text = getWinnerText(result.Winner);
            ReasonText.Text = getReasonText(result.Reason, gameState.CurrentPlayer);
        }

        private static string getWinnerText(Player winner)
        {
            switch (winner)
            {
                case Player.White:
                    return "WHITE PLAYER WINS!!!";
                case Player.Black:
                    return "BLACK PLAYER WINS!!!";
                default:
                    return "ITS A DRAW";
            }
        }


        private static string PlayerString(Player player)
        {
            switch (player)
            {
                case Player.White:
                    return "WHITE";
                case Player.Black:
                    return "BLACK";
                default:
                    return "";
            }
        }

        private static string getReasonText(END_GAME_REASONS reason, Player currentPlayer)
        {
            return reason switch
            {
                END_GAME_REASONS.Stealmate => $"STALEMATE - {PlayerString(currentPlayer)} CAN'T MOVE ",
                END_GAME_REASONS.Checkmate => $"CHECKMATE - {PlayerString(currentPlayer)} CAN'T MOVE ",
                END_GAME_REASONS.FiftyMoveRule => $"FIFTY MOVE RULE!!! ",
                END_GAME_REASONS.ThreefoldRepetition => $"THREEFOLDREPETITION!!!",
                END_GAME_REASONS.InsufficientMaterial => $"INSUFFICIENT MATERIAL",
                _ => ""
            };
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            optionSelected?.Invoke(OPTION.RESTART);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            optionSelected?.Invoke(OPTION.EXIT);
        }
    }
}
