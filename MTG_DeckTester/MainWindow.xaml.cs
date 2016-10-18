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
            WindowState = WindowState.Maximized;

            Game CurrentGame = Game.GetInstance();

            // ---------------------------- Initialisation de la partie ----------------------------
            //Joueur 1 (Joueur courant, en bas)
            CurrentGame.Set_Player(1, new Player("Aamond", "127.0.0.1"));
            CurrentGame.Set_Deck(1, Tools.ReadDeckXML(Tools.GetPath(ConfigKeys.DECKS) + "Zubera" + ".xml"));
            
            J1_Avatar.Set_DeckColor(CurrentGame.Get_Deck(1).CouleurDeck);
            J1_Avatar.Set_Avatar(CurrentGame.Get_Player(1).Name);
            J1_Avatar.Set_HP(20);

            //Joueur 2 (Adversaire, en haut)
            CurrentGame.Set_Player(2, new Player("Memnarck", "127.0.0.1"));
            CurrentGame.Set_Deck(2, Tools.ReadDeckXML(Tools.GetPath(ConfigKeys.DECKS) + "Zubera" + ".xml"));

            J2_Avatar.Set_DeckColor(CurrentGame.Get_Deck(2).CouleurDeck);
            J2_Avatar.Set_Avatar(CurrentGame.Get_Player(2).Name);
            J2_Avatar.Set_HP(20);

            //On mélange les decks
            Tools.Shuffle(CurrentGame.Get_Deck(1));

            //On pioche 7 cartes dans chaque deck
            for (int cpt = 0; cpt < 7; cpt++)
            {
                J1_Hand.Add_Card(Tools.Draw(CurrentGame.Get_Deck(1)));
                J2_Hand.Add_Card(Tools.Draw(CurrentGame.Get_Deck(2)));
            }
            
        }
    }
}
