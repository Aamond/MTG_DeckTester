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

            Tools.CurrentGame = Game.GetInstance();

            // ---------------------------- Initialisation de la partie ----------------------------

            //Initialisation des ID_Joueur dans les UserControls
            J1_DeckLists.ID_Joueur = 1;
            J1_Hand.ID_Joueur = 1;
            J1_Lands.ID_Joueur = 1;
            J1_Creatures.ID_Joueur = 1;
            J1_Specials.ID_Joueur = 1;

            J2_DeckLists.ID_Joueur = 2;
            J2_Hand.ID_Joueur = 2;
            J2_Lands.ID_Joueur = 2;
            J2_Creatures.ID_Joueur = 2;
            J2_Specials.ID_Joueur = 2;

            img_spellcast.Visibility = Visibility.Collapsed;

            //Joueur 1 (Joueur courant, en bas)
            Tools.CurrentGame.J1_Player = new Player("Aamond", "127.0.0.1");
            Tools.CurrentGame.J1_Deck = Tools.ReadDeckXML(Tools.GetPath(ConfigKeys.DECKS) + "Zubera" + ".xml");
            J1_Avatar.Set_DeckColor(Tools.CurrentGame.J1_Deck.CouleurDeck);
            J1_Avatar.Set_Avatar(Tools.CurrentGame.J1_Player.Name);
            J1_Avatar.Set_HP(20);

            //Joueur 2 (Adversaire, en haut)
            Tools.CurrentGame.J2_Player = new Player("Memnarck", "127.0.0.1");
            Tools.CurrentGame.J2_Deck = Tools.ReadDeckXML(Tools.GetPath(ConfigKeys.DECKS) + "Léonins_Equipements" + ".xml");
            J2_Avatar.Set_DeckColor(Tools.CurrentGame.J2_Deck.CouleurDeck);
            J2_Avatar.Set_Avatar(Tools.CurrentGame.J2_Player.Name);
            J2_Avatar.Set_HP(20);

            //Blocage des contrôles sur le terrain adverse
            J2_Avatar.IsEnabled = false;
            J2_DeckLists.IsEnabled = false;
            J2_Hand.IsEnabled = false;
            J2_Lands.IsEnabled = false;
            J2_Creatures.IsEnabled = false;
            J2_Specials.IsEnabled = false;

            //On mélange les decks
            Tools.Shuffle(Tools.CurrentGame.J1_Deck);
            Tools.Shuffle(Tools.CurrentGame.J2_Deck);

            //On pioche 7 cartes dans chaque deck
            for (int cpt = 0; cpt < 7; cpt++)
            {
                Tools.CurrentGame.J1_Main.Add(Tools.Draw(Tools.CurrentGame.J1_Deck));
                Tools.CurrentGame.J2_Main.Add(Tools.Draw(Tools.CurrentGame.J2_Deck));
            }
            J1_Hand.Refresh();
            J2_Hand.Refresh();
        }
    }
}
