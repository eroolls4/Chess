using Backend;
using FrontEnd;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace UI
{
    /// <summary>
    /// Interaction logic for PromotionMenu.xaml
    /// </summary>
    public partial class PromotionMenu : UserControl
    {

        public event Action<PIECE_TYPE> PromotionClick;

        public PromotionMenu(Player player)
        {
            InitializeComponent();

            QueenImg.Source = Images.GetImage(player, PIECE_TYPE.Queen);
            RookImg.Source= Images.GetImage(player,PIECE_TYPE.Rook);
            KnightImg.Source=Images.GetImage(player,PIECE_TYPE.Knight);
            BishopImg.Source=Images.GetImage(player,PIECE_TYPE.Bishop);
        }

        private void QueenImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PromotionClick?.Invoke(PIECE_TYPE.Queen);
        }

        private void RookImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PromotionClick?.Invoke(PIECE_TYPE.Rook);
        }

        private void BishopImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PromotionClick?.Invoke(PIECE_TYPE.Bishop);
        }

        private void KnightImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PromotionClick?.Invoke(PIECE_TYPE.Knight);
        }
    }
}
