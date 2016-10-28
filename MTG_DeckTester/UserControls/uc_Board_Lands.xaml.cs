using MTG_DeckTester.UserClasses;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MTG_DeckTester.UserControls
{
    /// <summary>
    /// Interaction logic for uc_Board_Lands.xaml
    /// </summary>
    public partial class uc_Board_Lands : UserControl
    {
        public int ID_Joueur;

        /// <summary>
        /// Constructeur du UserControl
        /// </summary>
        public uc_Board_Lands()
        {
            InitializeComponent();
            Init_uc_Board_Lands();
        }

        /// <summary>
        /// Réinitialisation de l'affichage au sein du UserControl
        /// </summary>
        private void Init_uc_Board_Lands()
        {
            foreach (var tmp in MainGrid_Lands.Children)
            {
                //Réinit des images
                if (tmp is Image)
                {
                    (tmp as Image).Source = new BitmapImage();
                }

                //Réinit des labels de nombre + remise à transparent des fond
                if (tmp is Grid)
                {
                    foreach (var tmp_2 in (tmp as Grid).Children)
                    {
                        if (tmp_2 is Label)
                        {
                            (tmp_2 as Label).Content = "";
                            (tmp_2 as Label).Background = new SolidColorBrush(Colors.Transparent);

                            if ((tmp_2 as Label).Name.Contains("NbLands"))
                            {
                                (tmp_2 as Label).Visibility = Visibility.Collapsed;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Raffraichis la visu sur la partie terrains
        /// </summary>
        public void Refresh()
        {
            int CptCartes;
            string NomImage;
            string NomLbl_NbLands;
            string NomLbl_Background;

            Init_uc_Board_Lands();

            if (ID_Joueur == 1)
            {
                for (CptCartes = 0; CptCartes < Tools.CurrentGame.J1_Board_Lands.Count; CptCartes++)
                {
                    NomImage = "img_land_card_" + CptCartes;
                    NomLbl_NbLands = "lbl_NbLands_" + CptCartes;
                    NomLbl_Background = "IsLinked_" + CptCartes;

                    //Mise à jour des éléments du UserControle
                    foreach (var tmp in MainGrid_Lands.Children)
                    {
                        //Si c'est une image, on set l'image selon la carte associé
                        if (tmp is Image && (tmp as Image).Name == NomImage)
                        {
                            (tmp as Image).Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + Tools.CurrentGame.J1_Board_Lands[CptCartes].ID_Carte));
                        }

                        //Si c'est un label indiquant les cartes de terrains engagés/nb total, on affiche le bon nombre si différent de 1, sinon on cache le label
                        if (tmp is Label && (tmp as Label).Name == NomLbl_NbLands)
                        {
                            if (Tools.CurrentGame.J1_Board_Lands[CptCartes].NbLands_Total == 1)
                            {
                                (tmp as Label).Visibility = Visibility.Collapsed;
                            }
                            else
                            {
                                (tmp as Label).Content = Tools.CurrentGame.J1_Board_Lands[CptCartes].NbLands_Total - Tools.CurrentGame.J1_Board_Lands[CptCartes].NbLands_Tapped + " / " + Tools.CurrentGame.J1_Board_Lands[CptCartes].NbLands_Total;
                                (tmp as Label).Visibility = Visibility.Visible;
                            }
                        }
                    }
                }
            }
            else if (ID_Joueur == 2)
            {
                for (CptCartes = 0; CptCartes < Tools.CurrentGame.J2_Board_Lands.Count; CptCartes++)
                {
                    NomImage = "img_land_card_" + CptCartes;
                    NomLbl_NbLands = "lbl_NbLands_" + CptCartes;
                    NomLbl_Background = "IsLinked_" + CptCartes;

                    //Mise à jour des éléments du UserControle
                    foreach (var tmp in MainGrid_Lands.Children)
                    {
                        //Si c'est une image, on set l'image selon la carte associé
                        if (tmp is Image && (tmp as Image).Name == NomImage)
                        {
                            (tmp as Image).Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + Tools.CurrentGame.J2_Board_Lands[CptCartes].ID_Carte));
                        }

                        //Si c'est un label indiquant les cartes de terrains engagés/nb total, on affiche le bon nombre si différent de 1, sinon on cache le label
                        if (tmp is Label && (tmp as Label).Name == NomLbl_NbLands)
                        {
                            if (Tools.CurrentGame.J2_Board_Lands[CptCartes].NbLands_Total == 1)
                            {
                                (tmp as Label).Visibility = Visibility.Collapsed;
                            }
                            else
                            {
                                (tmp as Label).Content = Tools.CurrentGame.J2_Board_Lands[CptCartes].NbLands_Total - Tools.CurrentGame.J2_Board_Lands[CptCartes].NbLands_Tapped + " / " + Tools.CurrentGame.J2_Board_Lands[CptCartes].NbLands_Total;
                                (tmp as Label).Visibility = Visibility.Visible;
                            }
                        }
                    }
                }
            }
        }
    }
}
