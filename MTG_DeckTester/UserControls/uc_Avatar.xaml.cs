using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.IO;
using MTG_DeckTester.UserClasses;

namespace MTG_DeckTester.UserControls
{

    public partial class uc_Avatar : UserControl
    {
        public int hp;

        public string player_name { get; set; }
        public string deck_color { get; set; }

        /// <summary>
        /// Constructeur du UserControls
        /// </summary>
        public uc_Avatar()
        {
            InitializeComponent();

            //Init des Hp (par défaut 20)
            int hp = 20;
            lbl_hp.Content = hp.ToString();
        }

        /// <summary>
        /// Initialise la couleur du deck (on passe la couleur en paramètre)
        /// </summary>
        /// <param name="deckColor">Couleur du deck</param>
        public void Set_DeckColor(string deckColor)
        {
            //Chargement de la couleur du deck
            deck_color = deckColor.ToUpper();
            switch (deck_color)
            {
                //Incolore
                case "UNCOLOR":
                    img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deckColor + ".png", UriKind.RelativeOrAbsolute));
                    break;
                //Bleu
                case "BLUE":
                    img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deckColor + ".png", UriKind.RelativeOrAbsolute));
                    break;
                //Rouge
                case "RED":
                    img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deckColor + ".png", UriKind.RelativeOrAbsolute));
                    break;
                //Vert
                case "GREEN":
                    img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deckColor + ".png", UriKind.RelativeOrAbsolute));
                    break;
                //Blanc
                case "WHITE":
                    img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deckColor + ".png", UriKind.RelativeOrAbsolute));
                    break;
                //Noir
                case "BLACK":
                    img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deckColor + ".png", UriKind.RelativeOrAbsolute));
                    break;
                //Autre cas, on utilise l'incolore
                default:
                    img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + "uncolor.png", UriKind.RelativeOrAbsolute));
                    break;
            }
        }

        /// <summary>
        /// Initialise l'avatar
        /// </summary>
        /// <param name="player_name">Nom du joueur</param>
        public void Set_Avatar(string player_name)
        {
            //Chargement de l'avatar
            if (Directory.Exists(Tools.GetPath(ConfigKeys.PLAYERS)))
            {
                if (File.Exists(Tools.GetPath(ConfigKeys.PLAYERS) + player_name + "\\" + player_name + ".png"))
                {
                    img_avatar.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.PLAYERS) + player_name + "\\" + player_name + ".png", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    img_avatar.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.PLAYERS) + player_name + "\\" + "default.png", UriKind.RelativeOrAbsolute));
                }
            }
        }

        /// <summary>
        /// Change les points de vie
        /// </summary>
        /// <param name="hp_Param">Points de vie</param>
        public void Set_HP(int hp_Param)
        {
            int hp = hp_Param;
            lbl_hp.Content = hp_Param.ToString();
        }

        /// <summary>
        /// Décrémente de 1 les PDV
        /// </summary>
        /// <param name="sender">Bouton</param>
        /// <param name="e">Évènement</param>
        private void Hp_Down(object sender, MouseButtonEventArgs e)
        {
            hp--;
            lbl_hp.Content = hp.ToString();
        }

        /// <summary>
        /// Incrémente de 1 les PDV
        /// </summary>
        /// <param name="sender">Bouton</param>
        /// <param name="e">Évènement</param>
        private void Hp_Up(object sender, MouseButtonEventArgs e)
        {
            hp++;
            lbl_hp.Content = hp.ToString();
        }

        /// <summary>
        /// Fonction de changement de l'icone de couleur (par double-clic)
        /// (Fonctionne de manière circulaire)
        /// </summary>
        /// <param name="sender">Bouton cliqué</param>
        /// <param name="e">Evenement Double clic</param>
        private void Change_DeckColor(object sender, MouseButtonEventArgs e)
        {
            bool exit = false;

            if (deck_color == "UNCOLOR" && !exit)
            {
                deck_color = "BLUE";
                img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deck_color + ".png", UriKind.RelativeOrAbsolute));
                exit = true;
            }

            if (deck_color == "BLUE" && !exit)
            {
                deck_color = "GREEN";
                img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deck_color + ".png", UriKind.RelativeOrAbsolute));
                exit = true;
            }

            if (deck_color == "GREEN" && !exit)
            {
                deck_color = "RED";
                img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deck_color + ".png", UriKind.RelativeOrAbsolute));
                exit = true;
            }

            if (deck_color == "RED" && !exit)
            {
                deck_color = "WHITE";
                img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deck_color + ".png", UriKind.RelativeOrAbsolute));
                exit = true;
            }

            if (deck_color == "WHITE" && !exit)
            {
                deck_color = "BLACK";
                img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deck_color + ".png", UriKind.RelativeOrAbsolute));
                exit = true;
            }

            if (deck_color == "BLACK" && !exit)
            {
                deck_color = "UNCOLOR";
                img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deck_color + ".png", UriKind.RelativeOrAbsolute));
                exit = true;
            }
        }
    }
}
