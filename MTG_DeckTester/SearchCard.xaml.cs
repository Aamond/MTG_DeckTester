using MTG_DeckTester.UserClasses;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MTG_DeckTester
{
    /// <summary>
    /// Interaction logic for SearchCard.xaml
    /// </summary>
    public partial class SearchCard : Window
    {
        public List<Card> Cards;

        public SearchCard(List<Card> cardList)
        {
            InitializeComponent();
            Cards = cardList;
            Loaded += SearchCard_Loaded;
        }

        private void SearchCard_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Cards.Count; i++)
            {
                Grid grd = new Grid();
                grd.Height = 50;
                grd.MinWidth = 420;
                grd.HorizontalAlignment = HorizontalAlignment.Stretch;
                grd.VerticalAlignment = VerticalAlignment.Top;
                grd.Margin = new Thickness(2);

                //A compléter avec l'ajout des composants (label, boutons, ...) dont on a besoin
                grd.Background = new SolidColorBrush(Colors.Red);
                
                wpCards.Children.Add(grd);
            }
        }
    }
}
