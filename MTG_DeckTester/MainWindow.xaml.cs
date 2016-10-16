using MTG_DeckTester.UserClasses;
using System.Windows;

namespace MTG_DeckTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {            
            InitializeComponent();

            Game CurrentGame = Game.GetInstance();

            //Initialisation de la partie
            //Joueur 1
            CurrentGame.Set_Player(1, new Player("Aamond", "127.0.0.1"));
            CurrentGame.Set_Deck(1, Tools.ReadDeckXML(Tools.GetPath(ConfigKeys.DECKS) + "Zubera" + ".xml"));
            
            J1_Avatar.Set_DeckColor(CurrentGame.Get_Deck(1).CouleurDeck);
            J1_Avatar.Set_Avatar(CurrentGame.Get_Player(1).Name);

            //MAGIC - On mélange le deck
            Tools.Shuffle(CurrentGame.Get_Deck(1));

            //MAGIC - On pioche 7 cartes
            for (int cpt = 0; cpt < 7; cpt++)
            {
                J1_Hand.Add_Card(Tools.Draw(CurrentGame.Get_Deck(1)));
            }
            
        }
    }
}
