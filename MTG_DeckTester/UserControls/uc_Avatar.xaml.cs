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
            switch (deck_color)
            {
                //Incolore
                case "uncolor":
                    img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deckColor + ".png", UriKind.RelativeOrAbsolute));
                    break;
                //Bleu
                case "blue":
                    img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deckColor + ".png", UriKind.RelativeOrAbsolute));
                    break;
                //Rouge
                case "red":
                    img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deckColor + ".png", UriKind.RelativeOrAbsolute));
                    break;
                //Vert
                case "green":
                    img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deckColor + ".png", UriKind.RelativeOrAbsolute));
                    break;
                //Blanc
                case "white":
                    img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deckColor + ".png", UriKind.RelativeOrAbsolute));
                    break;
                //Noir
                case "black":
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
        public void Set_PlayerName(string player_name)
        {
            //Chargement de l'avatar
            if (Directory.Exists(Tools.GetPath(ConfigKeys.PLAYERS)))
            {
                if (File.Exists(Tools.GetPath(ConfigKeys.PLAYERS) + player_name + ".png"))
                {

                    BitmapImage b = new BitmapImage();
                    b.BeginInit();
                    b.UriSource = new Uri(Tools.GetPath(ConfigKeys.PLAYERS) + player_name + ".png");
                    b.EndInit();
                    img_avatar.Source = b;
                }
                else
                {
                    BitmapImage b = new BitmapImage();
                    b.BeginInit();
                    b.UriSource = new Uri(Tools.GetPath(ConfigKeys.PLAYERS) + "default.png");
                    b.EndInit();
                    img_avatar.Source = b;
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
            if (deck_color == "uncolor")
            {
                deck_color = "blue";
                img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deck_color + ".png", UriKind.Relative));
            }

            if (deck_color == "blue")
            {
                deck_color = "green";
                img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deck_color + ".png", UriKind.Relative));
            }

            if (deck_color == "red")
            {
                deck_color = "green";
                img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deck_color + ".png", UriKind.Relative));
            }

            if (deck_color == "green")
            {
                deck_color = "white";
                img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deck_color + ".png", UriKind.Relative));
            }

            if (deck_color == "white")
            {
                deck_color = "black";
                img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deck_color + ".png", UriKind.Relative));
            }

            if (deck_color == "black")
            {
                deck_color = "uncolor";
                img_deck_color.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.DECK_COLOR) + deck_color + ".png", UriKind.Relative));
            }
        }
    }
}
