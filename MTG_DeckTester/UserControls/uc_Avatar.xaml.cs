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
        public string deck_color;

        public uc_Avatar()
        {
            string _uri;
            string _dossier;

            InitializeComponent();

            //Init des Hp (par défaut 20)
            int hp = 20;
            lbl_hp.Content = hp.ToString();

            //Chargement de l'avatar
            _dossier = "./players/" + Global.CurrentUser_Name;
            if (Directory.Exists(_dossier))
            {
                if (File.Exists(_dossier + "/" + Global.CurrentUser_Name + ".png"))
                {
                    BitmapImage b = new BitmapImage();
                    b.BeginInit();
                    b.UriSource = new Uri("pack://application:,,,/players/Aamond.png");
                    b.EndInit();
                    img_avatar.Source = b;
                }
                else
                {
                    BitmapImage b = new BitmapImage();
                    b.BeginInit();
                    b.UriSource = new Uri(_dossier + "default.png");
                    b.EndInit();
                    img_avatar.Source = b;
                }
            }

            //Chargement de la couleur du deck                
            _uri = "img/deck_colors/";
            switch (deck_color)
            {
                //Incolore
                case "uncolor":
                    img_deck_color.Source = new BitmapImage(new Uri(_uri + deck_color + ".png", UriKind.Relative));
                    break;
                //Bleu
                case "blue":
                    img_deck_color.Source = new BitmapImage(new Uri(_uri + deck_color + ".png", UriKind.Relative));
                    break;
                //Rouge
                case "red":
                    img_deck_color.Source = new BitmapImage(new Uri(_uri + deck_color + ".png", UriKind.Relative));
                    break;
                //Vert
                case "green":
                    img_deck_color.Source = new BitmapImage(new Uri(_uri + deck_color + ".png", UriKind.Relative));
                    break;
                //Blanc
                case "white":
                    img_deck_color.Source = new BitmapImage(new Uri(_uri + deck_color + ".png", UriKind.Relative));
                    break;
                //Noir
                case "black":
                    img_deck_color.Source = new BitmapImage(new Uri(_uri + deck_color + ".png", UriKind.Relative));
                    break;
                //Autre cas, on utilise l'incolore
                default:
                    img_deck_color.Source = new BitmapImage(new Uri(_uri + "uncolor.png", UriKind.Relative));
                    break;
            }
        }

        private void Hp_Down(object sender, MouseButtonEventArgs e)
        {
            hp--;
            lbl_hp.Content = hp.ToString();
        }

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
            string DeckColor_Path = "img/deck_colors/";

            if (deck_color == "uncolor")
            {
                deck_color = "blue";
                img_deck_color.Source = new BitmapImage(new Uri(DeckColor_Path + deck_color + ".png", UriKind.Relative));
            }

            if (deck_color == "blue")
            {
                deck_color = "green";
                img_deck_color.Source = new BitmapImage(new Uri(DeckColor_Path + deck_color + ".png", UriKind.Relative));
            }

            if (deck_color == "red")
            {
                deck_color = "green";
                img_deck_color.Source = new BitmapImage(new Uri(DeckColor_Path + deck_color + ".png", UriKind.Relative));
            }

            if (deck_color == "green")
            {
                deck_color = "white";
                img_deck_color.Source = new BitmapImage(new Uri(DeckColor_Path + deck_color + ".png", UriKind.Relative));
            }

            if (deck_color == "white")
            {
                deck_color = "black";
                img_deck_color.Source = new BitmapImage(new Uri(DeckColor_Path + deck_color + ".png", UriKind.Relative));
            }

            if (deck_color == "black")
            {
                deck_color = "uncolor";
                img_deck_color.Source = new BitmapImage(new Uri(DeckColor_Path + deck_color + ".png", UriKind.Relative));
            }
        }
    }
}
