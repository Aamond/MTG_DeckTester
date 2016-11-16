using MTG_DeckTester.UserClasses;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MTG_DeckTester.UserControls
{
    /// <summary>
    /// Interaction logic for uc_Board_Creatures.xaml
    /// </summary>
    public partial class uc_Board_Creatures : UserControl
    {
        public int ID_Joueur;

        public uc_Board_Creatures()
        {
            InitializeComponent();
            Init_uc_Board_Creatures();
        }

        /// <summary>
        /// Réinitialisation de l'affichage au sein du UserControl
        /// </summary>
        private void Init_uc_Board_Creatures()
        {
            foreach (var tmp in MainGrid_Creatures.Children)
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

                            if ((tmp_2 as Label).Name.Contains("Creature_Marks"))
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
            string NomLbl_Marks;
            string NomLbl_Background;

            Init_uc_Board_Creatures();

            if (ID_Joueur == 1)
            {
                for (CptCartes = 0; CptCartes < Tools.CurrentGame.J1_Board_Creatures.Count; CptCartes++)
                {
                    NomImage = "img_Creature_card_" + Tools.GetNextPlaceCard(CptCartes).ToString("D2");
                    NomLbl_Marks = "lbl_Creature_Marks_" + Tools.GetNextPlaceCard(CptCartes).ToString("D2");
                    NomLbl_Background = "IsLinked_" + Tools.GetNextPlaceCard(CptCartes).ToString("D2");

                    //Mise à jour des éléments du UserControle
                    foreach (var grid in MainGrid_Creatures.Children)
                    {
                        if (grid is Grid)
                        {
                            foreach (var tmp in (grid as Grid).Children)
                            {
                                //Si c'est une image, on set l'image selon la carte associée
                                if (tmp is Image && (tmp as Image).Name == NomImage)
                                {
                                    (tmp as Image).Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + Tools.CurrentGame.J1_Board_Creatures[CptCartes].ID_Carte));
                                }

                                //Si c'est un label indiquant les marqueurs de la carte, on affiche : (<NbMarqueurs>) Nom_Marqueur, si 0 marqueur, on cache le label.
                                if (tmp is Label && (tmp as Label).Name == NomLbl_Marks)
                                {
                                    if (Tools.CurrentGame.J1_Board_Creatures[CptCartes].Marqueur.NbMarqueur == 0)
                                    {
                                        (tmp as Label).Background = Brushes.Transparent;
                                        (tmp as Label).Visibility = Visibility.Collapsed;
                                    }
                                    else
                                    {
                                        (tmp as Label).Background = Brushes.White;
                                        (tmp as Label).Content = "(" + Tools.CurrentGame.J1_Board_Creatures[CptCartes].Marqueur.NbMarqueur + ") " + Tools.CurrentGame.J1_Board_Creatures[CptCartes].Marqueur.MarqueurName;
                                        (tmp as Label).Visibility = Visibility.Visible;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (ID_Joueur == 2)
            {
                for (CptCartes = 0; CptCartes < Tools.CurrentGame.J2_Board_Creatures.Count; CptCartes++)
                {
                    NomImage = "img_Creature_card_" + Tools.GetNextPlaceCard(CptCartes).ToString("D2");
                    NomLbl_Marks = "lbl_Creature_Marks_" + Tools.GetNextPlaceCard(CptCartes).ToString("D2");
                    NomLbl_Background = "IsLinked_" + Tools.GetNextPlaceCard(CptCartes).ToString("D2");

                    //Mise à jour des éléments du UserControle
                    foreach (var grid in MainGrid_Creatures.Children)
                    {
                        if (grid is Grid)
                        {
                            foreach (var tmp in (grid as Grid).Children)
                            {
                                //Si c'est une image, on set l'image selon la carte associée
                                if (tmp is Image && (tmp as Image).Name == NomImage)
                                {
                                    (tmp as Image).Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + Tools.CurrentGame.J2_Board_Creatures[CptCartes].ID_Carte));
                                }

                                //Si c'est un label indiquant les marqueurs de la carte, on affiche : (<NbMarqueurs>) Nom_Marqueur, si 0 marqueur, on cache le label.
                                if (tmp is Label && (tmp as Label).Name == NomLbl_Marks)
                                {
                                    if (Tools.CurrentGame.J2_Board_Creatures[CptCartes].Marqueur.NbMarqueur == 0)
                                    {
                                        (tmp as Label).Visibility = Visibility.Collapsed;
                                    }
                                    else
                                    {
                                        (tmp as Label).Content = "(" + Tools.CurrentGame.J2_Board_Creatures[CptCartes].Marqueur.NbMarqueur + ") " + Tools.CurrentGame.J2_Board_Creatures[CptCartes].Marqueur.MarqueurName;
                                        (tmp as Label).Visibility = Visibility.Visible;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Affiche la carte en plus gros au dessus au survol de la carte dans la main
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Show_Card(object sender, System.Windows.Input.MouseEventArgs e)
        {
            int indice_card;
            Image img_tmp;
            string NomImage_Carte;
            string NomGrid_Carte;
            string NomImage_Visionneuse;

            img_tmp = new Image();
            indice_card = Int32.Parse((sender as Label).Name.Substring(8, 2));
            NomImage_Visionneuse = "img_view_" + indice_card.ToString("D2") + "_J" + ID_Joueur.ToString();
            NomGrid_Carte = "grid_Card_" + indice_card.ToString("D2");
            NomImage_Carte = "img_Creature_card_" + indice_card.ToString("D2");

            foreach (var grd in MainGrid_Creatures.Children)
            {
                if (grd is Grid && (grd as Grid).Name == NomGrid_Carte)
                {
                    foreach (var img_card in (grd as Grid).Children)
                    {
                        if (img_card is Image && (img_card as Image).Name == NomImage_Carte)
                        {
                            img_tmp = img_card as Image;
                            break;
                        }
                    }

                    if (img_tmp.Source != new BitmapImage())
                    {
                        foreach (var img_view in MainGrid_Creatures.Children)
                        {
                            if (img_view is Image && (img_view as Image).Name == NomImage_Visionneuse)
                            {
                                (img_view as Image).Source = img_tmp.Source;
                                (img_view as Image).Visibility = System.Windows.Visibility.Visible;
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Cache l'affichage en plus gros de la carte quand on quitte l'image de la carte dans la main
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void End_Show_Card(object sender, System.Windows.Input.MouseEventArgs e)
        {
            int indice_card;
            Image img_tmp;
            string NomImage_Carte;
            string NomGrid_Carte;
            string NomImage_Visionneuse;

            img_tmp = new Image();
            indice_card = Int32.Parse((sender as Label).Name.Substring(8, 2));
            NomImage_Visionneuse = "img_view_" + indice_card.ToString("D2") + "_J" + ID_Joueur.ToString();
            NomGrid_Carte = "grid_Card_" + indice_card.ToString("D2");
            NomImage_Carte = "img_Creature_card_" + indice_card.ToString("D2");

            foreach (var grd in MainGrid_Creatures.Children)
            {
                if (grd is Grid && (grd as Grid).Name == NomGrid_Carte)
                {
                    foreach (var img_card in (grd as Grid).Children)
                    {
                        if (img_card is Image && (img_card as Image).Name == NomImage_Carte)
                        {
                            img_tmp = img_card as Image;
                            break;
                        }
                    }
                }
            }

            if (img_tmp.Source != new BitmapImage())
            {
                foreach (var img_view in MainGrid_Creatures.Children)
                {
                    if (img_view is Image && (img_view as Image).Name == NomImage_Visionneuse)
                    {
                        (img_view as Image).Source = new BitmapImage();
                        (img_view as Image).Visibility = System.Windows.Visibility.Collapsed;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Envoie la carte ciblée de la main du joueur dans le deck, on mélange ensuite le deck
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendTo_Deck(object sender, RoutedEventArgs e)
        {
            int indice_card;
            string NomImage_Carte;
            string NomGrid_Carte;

            //On gère ici uniquement les évènements du joueur 1
            //Les évènements du joueur 2 seront gérés par le module de communication
            if (ID_Joueur == 1)
            {
                indice_card = Int32.Parse((sender as MenuItem).Name.Substring(9, 2));
                NomGrid_Carte = "grid_Card_" + indice_card.ToString("D2");
                NomImage_Carte = "img_Creature_card_" + indice_card.ToString("D2");

                foreach (var grd in MainGrid_Creatures.Children)
                {
                    if (grd is Grid && (grd as Grid).Name == NomGrid_Carte)
                    {
                        foreach (var img_card in (grd as Grid).Children)
                        {
                            if (img_card is Image && (img_card as Image).Name == NomImage_Carte && (img_card as Image).Source != new BitmapImage())
                            {
                                (img_card as Image).Source = new BitmapImage();
                                Tools.CurrentGame.J1_Deck.Cartes.Add(Tools.CurrentGame.J1_Board_Creatures[Tools.GetIndiceCardFromBoard(indice_card)].ToCard());
                                Tools.CurrentGame.J1_Board_Creatures.Remove(Tools.CurrentGame.J1_Board_Creatures[Tools.GetIndiceCardFromBoard(indice_card)]);
                                Refresh();
                                Tools.Shuffle(Tools.CurrentGame.J1_Deck);
                                Tools.CurrentMainWindow.uc_DeckLists_Refresh(ID_Joueur);
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Envoie la carte ciblée de la main du joueur dans le cimetière
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendTo_Graveyard(object sender, RoutedEventArgs e)
        {
            int indice_card;
            string NomImage_Carte;
            string NomGrid_Carte;

            //On gère ici uniquement les évènements du joueur 1
            //Les évènements du joueur 2 seront gérés par le module de communication
            if (ID_Joueur == 1)
            {
                indice_card = Int32.Parse((sender as MenuItem).Name.Substring(9, 2));
                NomGrid_Carte = "grid_Card_" + indice_card.ToString("D2");
                NomImage_Carte = "img_Creature_card_" + indice_card.ToString("D2");

                foreach (var grd in MainGrid_Creatures.Children)
                {
                    if (grd is Grid && (grd as Grid).Name == NomGrid_Carte)
                    {
                        foreach (var img_card in (grd as Grid).Children)
                        {
                            (img_card as Image).Source = new BitmapImage();
                            Tools.CurrentGame.J1_Cimetiere.Add(Tools.CurrentGame.J1_Board_Creatures[Tools.GetIndiceCardFromBoard(indice_card)]);
                            Tools.CurrentGame.J1_Board_Creatures.Remove(Tools.CurrentGame.J1_Board_Creatures[Tools.GetIndiceCardFromBoard(indice_card)]);
                            Refresh();
                            Tools.CurrentMainWindow.uc_DeckLists_Refresh(ID_Joueur);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Envoie la carte ciblée de la main du joueur à l'exil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendTo_Exile(object sender, RoutedEventArgs e)
        {
            int indice_card;
            string NomImage_Carte;
            string NomGrid_Carte;

            //On gère ici uniquement les évènements du joueur 1
            //Les évènements du joueur 2 seront gérés par le module de communication
            if (ID_Joueur == 1)
            {
                indice_card = Int32.Parse((sender as MenuItem).Name.Substring(9, 2));
                NomGrid_Carte = "grid_Card_" + indice_card.ToString("D2");
                NomImage_Carte = "img_Creature_card_" + indice_card.ToString("D2");

                foreach (var grd in MainGrid_Creatures.Children)
                {
                    if (grd is Grid && (grd as Grid).Name == NomGrid_Carte)
                    {
                        foreach (var img_card in (grd as Grid).Children)
                        {
                            if (img_card is Image && (img_card as Image).Name == NomImage_Carte && (img_card as Image).Source != new BitmapImage())
                            {
                                (img_card as Image).Source = new BitmapImage();
                                Tools.CurrentGame.J1_Exil.Add(Tools.CurrentGame.J1_Board_Creatures[Tools.GetIndiceCardFromBoard(indice_card)]);
                                Tools.CurrentGame.J1_Board_Creatures.Remove(Tools.CurrentGame.J1_Board_Creatures[Tools.GetIndiceCardFromBoard(indice_card)]);
                                Refresh();
                                Tools.CurrentMainWindow.uc_DeckLists_Refresh(ID_Joueur);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
