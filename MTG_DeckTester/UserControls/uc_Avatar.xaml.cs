using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using System.Windows.Shapes;
using System.Configuration;

namespace MTG_DeckTester.UserControls
{

    public partial class uc_Avatar : UserControl
    {
        int hp;
        string deck_color;

        public uc_Avatar()
        {

            string CurrentUser_Name = "Aamond";
            string _uri;
            string _dossier;

            InitializeComponent();

            //Init des Hp (par défaut 20)
            int hp = 20;
            lbl_hp.Content = hp.ToString();

            //Chargement de l'avatar
            _dossier = ConfigurationManager.AppSettings["playerDirectory"];
            if (Directory.Exists(_dossier))
            {
                if (File.Exists(_dossier + "/" + CurrentUser_Name + ".png"))
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
                //Autre cas, non géré
                default:
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

        private void Change_DeckColor(object sender, MouseButtonEventArgs e)
        {
            string _uri = "img/deck_colors / ";

            if (deck_color == "uncolor")
            {
                deck_color = "blue";
                img_deck_color.Source = new BitmapImage(new Uri(_uri + deck_color + ".png", UriKind.Relative));
            }

            if (deck_color == "blue")
            {
                deck_color = "red";
                BitmapImage b = new BitmapImage();
                b.BeginInit();
                b.UriSource = new Uri(_uri + deck_color + ".png", UriKind.Relative);
                b.EndInit();
                img_deck_color.Source = b;
            }

            if (deck_color == "red")
            {
                deck_color = "green";
                img_deck_color.Source = new BitmapImage(new Uri(_uri + deck_color + ".png", UriKind.Relative));
            }

            if (deck_color == "green")
            {
                deck_color = "white";
                img_deck_color.Source = new BitmapImage(new Uri(_uri + deck_color + ".png", UriKind.Relative));
            }

            if (deck_color == "white")
            {
                deck_color = "black";
                img_deck_color.Source = new BitmapImage(new Uri(_uri + deck_color + ".png", UriKind.Relative));
            }

            if (deck_color == "black")
            {
                deck_color = "uncolor";
                img_deck_color.Source = new BitmapImage(new Uri(_uri + deck_color + ".png", UriKind.Relative));
            }
        }
    }
}
