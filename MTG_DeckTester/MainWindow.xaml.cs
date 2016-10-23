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
            CurrentGame.J1_Player = new Player("Aamond", "127.0.0.1");
            CurrentGame.J1_Deck = Tools.ReadDeckXML(Tools.GetPath(ConfigKeys.DECKS) + "Zubera" + ".xml");
            J1_Hand.ID_Joueur = 1;
            J1_Avatar.Set_DeckColor(CurrentGame.J1_Deck.CouleurDeck);
            J1_Avatar.Set_Avatar(CurrentGame.J1_Player.Name);
            J1_Avatar.Set_HP(20);

            //Joueur 2 (Adversaire, en haut)
            CurrentGame.J2_Player = new Player("Memnarck", "127.0.0.1");
            CurrentGame.J2_Deck = Tools.ReadDeckXML(Tools.GetPath(ConfigKeys.DECKS) + "Léonins_Equipements" + ".xml");
            J2_Hand.ID_Joueur = 2;
            J2_Avatar.Set_DeckColor(CurrentGame.J2_Deck.CouleurDeck);
            J2_Avatar.Set_Avatar(CurrentGame.J2_Player.Name);
            J2_Avatar.Set_HP(20);

            //Blocage des contrôles sur le terrain adverse
            J2_Avatar.IsEnabled = false;
            J2_DeckLists.IsEnabled = false;
            J2_Hand.IsEnabled = false;
            J2_Lands.IsEnabled = false;
            J2_Creatures.IsEnabled = false;
            J2_Specials.IsEnabled = false;

            //On mélange les decks
            Tools.Shuffle(CurrentGame.J1_Deck);
            Tools.Shuffle(CurrentGame.J2_Deck);

            //On pioche 7 cartes dans chaque deck
            for (int cpt = 0; cpt < 7; cpt++)
            {
                J1_Hand.Add_Card(Tools.Draw(CurrentGame.J1_Deck));
                J2_Hand.Add_Card(Tools.Draw(CurrentGame.J2_Deck));
            }
        }
    }
}
