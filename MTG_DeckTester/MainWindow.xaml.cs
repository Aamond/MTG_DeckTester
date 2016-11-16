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
            Tools.CurrentMainWindow = this;
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
            btn_Actions_J2.IsEnabled = false;

            //On mélange les decks
            Tools.Shuffle(Tools.CurrentGame.J1_Deck);
            Tools.Shuffle(Tools.CurrentGame.J2_Deck);

            //On pioche 7 cartes dans chaque deck(
            for (int cpt = 0; cpt < 7; cpt++)
            {
                Tools.CurrentGame.J1_Main.Add(Tools.Draw(Tools.CurrentGame.J1_Deck));
                Tools.CurrentGame.J2_Main.Add(Tools.Draw(Tools.CurrentGame.J2_Deck));
            }
            J1_Hand.Refresh();
            J2_Hand.Refresh();

            J1_DeckLists.Refresh();            
        }

        /// <summary>
        /// Refresh des uc Hand
        /// </summary>
        /// <param name="id_param">ID du joueur pour lequel on refresh la main</param>
        public void uc_Hands_Refresh(int id_joueur_param)
        {
            switch (id_joueur_param)
            {
                case 1:
                    J1_Hand.Refresh();
                    break;
                case 2:
                    J2_Hand.Refresh();
                    break;
                case 9:
                    J1_Hand.Refresh();
                    J2_Hand.Refresh();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Refresh des uc deck
        /// </summary>
        /// <param name="id_param">ID du joueur pour lequel on refresh les listes de paquets</param>
        public void uc_DeckLists_Refresh(int id_joueur_param)
        {
            switch (id_joueur_param)
            {
                case 1:
                    J1_DeckLists.Refresh();
                    break;
                case 2:
                    J2_DeckLists.Refresh();
                    break;
                case 9:
                    J1_DeckLists.Refresh();
                    J2_DeckLists.Refresh();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Refresh des uc Board_Lands
        /// </summary>
        /// <param name="id_param">ID du joueur pour lequel on refresh la partie du terrain dédié aux manas</param>
        public void uc_Board_Lands_Refresh(int id_joueur_param)
        {
            switch (id_joueur_param)
            {
                case 1:
                    J1_Lands.Refresh();
                    break;
                case 2:
                    J2_Lands.Refresh();
                    break;
                case 9:
                    J1_Lands.Refresh();
                    J2_Lands.Refresh();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Refresh des uc Board_Creatures
        /// </summary>
        /// <param name="id_param">ID du joueur pour lequel on refresh la partie du terrain dédié aux créatures</param>
        public void uc_Board_Creatures_Refresh(int id_joueur_param)
        {
            switch (id_joueur_param)
            {
                case 1:
                    J1_Creatures.Refresh();
                    break;
                case 2:
                    J2_Creatures.Refresh();
                    break;
                case 9:
                    J1_Creatures.Refresh();
                    J2_Creatures.Refresh();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Refresh des uc Board_Specials
        /// </summary>
        /// <param name="id_param">ID du joueur pour lequel on refresh la partie du terrain dédié aux cartes enchantements/artefacts ...</param>
        public void uc_Board_Specials_Refresh(int id_joueur_param)
        {
            switch (id_joueur_param)
            {
                case 1:
                    J1_Specials.Refresh();
                    break;
                case 2:
                    J2_Specials.Refresh();
                    break;
                case 9:
                    J1_Specials.Refresh();
                    J2_Specials.Refresh();
                    break;
                default:
                    break;
            }
        }

        private void OpenActionMenu(object sender, RoutedEventArgs e)
        {
            int CptCartes;

            for(CptCartes = Tools.CurrentGame.J1_Main.Count - 1; CptCartes >= 0; CptCartes--)
            {
                Tools.CurrentGame.J1_Deck.Cartes.Add(Tools.CurrentGame.J1_Main[CptCartes]);
                Tools.CurrentGame.J1_Main.Remove(Tools.CurrentGame.J1_Main[CptCartes]);
            }

            Tools.Shuffle(Tools.CurrentGame.J1_Deck);

            for(CptCartes = 0; CptCartes < 7; CptCartes++)
            {
                Tools.CurrentGame.J1_Main.Add(Tools.Draw(Tools.CurrentGame.J1_Deck));
            }

            uc_Hands_Refresh(1);
            uc_DeckLists_Refresh(1);
        }
    }
}
