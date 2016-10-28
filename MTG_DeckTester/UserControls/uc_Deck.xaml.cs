using MTG_DeckTester.UserClasses;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MTG_DeckTester.UserControls
{
    /// <summary>
    /// Interaction logic for uc_Board_Deck.xaml
    /// </summary>
    public partial class uc_Board_Deck : UserControl
    {
        public int ID_Joueur;

        /// <summary>
        /// Constructeur du UserControl Deck/Cimetiere/Exil
        /// </summary>
        public uc_Board_Deck()
        {
            InitializeComponent();

            img_deck_card.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + "000000.jpg", UriKind.RelativeOrAbsolute));
            img_graveyard_card.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + "000000.jpg", UriKind.RelativeOrAbsolute));
            img_exile_card.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + "000000.jpg", UriKind.RelativeOrAbsolute));
        }
    }
}
