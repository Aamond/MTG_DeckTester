using MTG_DeckTester.UserClasses;
using System;
using System.Collections.Generic;
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
        public List<Land_Card> Lands_Joueur;

        /// <summary>
        /// Constructeur du UserControl
        /// </summary>
        public uc_Board_Lands()
        {            
            InitializeComponent();
            Init_uc_Board_Lands();
            Lands_Joueur = new List<Land_Card>();
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
                    (tmp as Image).Source = null;
                }

                //Réinit des labels de nombre + remise à transparent des fond
                if (tmp is Label)
                {
                    (tmp as Label).Content = "";
                    (tmp as Label).Background = new SolidColorBrush(Colors.Transparent);
                    
                    if((tmp as Label).Name.Contains("NbLands"))
                    {
                        (tmp as Label).Visibility = Visibility.Collapsed;
                    }
                }
            }
        }

        /// <summary>
        /// Raffraichis la visu sur la partie terrains
        /// </summary>
        private void Refresh()
        {
            int CptCartes;
            string NomImage;
            string NomLbl_NbLands;
            string NomLbl_Background;

            Init_uc_Board_Lands();

            for (CptCartes = 0; CptCartes < Lands_Joueur.Count; CptCartes++)
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
                        (tmp as Image).Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + Lands_Joueur[CptCartes].ID_Carte));
                    }

                    ////MISE A JOUR SI TERRAINS ENCHANTES - A REVOIR CAR ÇA PUE
                    ////Si c'est un label dédié aux terrains enchantés, voir plus bas le détail (car un peu complexe)
                    //if (tmp is Label && (tmp as Label).Name == NomLbl_Background)
                    //{
                    //    //Si le terrain est enchanté
                    //    if (Lands_Joueur[CptCartes].IsLinked)
                    //    {
                    //        //Si le terrain courant n'est pas stack avec d'autres, on mets le fond de la carte en jaune
                    //        if (Lands_Joueur[CptCartes].NbLands_Total == 1)
                    //        {
                    //            (tmp as Label).Background = new SolidColorBrush(Colors.Yellow);
                    //        }

                    //        //Sinon, on retire 1 du label des nombres (et on le cache s'il tombe à 1) et on affiche le terrain que l'on "déplace" sur la première image dispo du UserControl
                    //        else
                    //        {
                    //            //On parcours les images
                    //            foreach (var img in MainGrid_Lands.Children)
                    //            {
                    //                if (img is Image)
                    //                {
                    //                    //Dès que l'on trouve une image.source à null, on mets l'image de la carte, et on retire 1 au nombre de carte total de terrain en question
                    //                    if ((img as Image).Source != null)
                    //                    {
                    //                        (img as Image).Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + Lands_Joueur[CptCartes].ID_Carte));
                    //                        if (Lands_Joueur[CptCartes].NbLands_Total > 1) { Lands_Joueur[CptCartes].NbLands_Total--; }
                    //                        if (Lands_Joueur[CptCartes].NbLands_Tapped > 1) { Lands_Joueur[CptCartes].NbLands_Tapped--; }
                    //                    }
                    //                }
                    //            }
                    //        }
                    //        break;
                    //    }
                    //    //Sinon, on mets le fond de la carte en transparent
                    //    else
                    //    {
                    //        (tmp as Label).Background = new SolidColorBrush(Colors.Transparent);
                    //    }
                    //}

                    //Si c'est un label indiquant les cartes de terrains engagés/nb total, on affiche le bon nombre si différent de 1, sinon on cache le label
                    if (tmp is Label && (tmp as Label).Name == NomLbl_NbLands)
                    {
                        if (Lands_Joueur[CptCartes].NbLands_Total == 1)
                        {
                            (tmp as Label).Visibility = Visibility.Collapsed;
                        }
                        else
                        {
                            (tmp as Label).Content = Lands_Joueur[CptCartes].NbLands_Total - Lands_Joueur[CptCartes].NbLands_Tapped + " / " + Lands_Joueur[CptCartes].NbLands_Total;
                            (tmp as Label).Visibility = Visibility.Visible;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Retourne l'index du terrain trouvé, retourne -1 si absent de la liste
        /// </summary>
        /// <param name="cInstance"></param>
        /// <returns>Index du terrain trouvé (-1 si non trouvé)</returns>
        public int FindCard(Land_Card cInstance)
        {
            if (Lands_Joueur.Find(r => r.ID_Carte == cInstance.ID_Carte) != null)
            {
                return Lands_Joueur.IndexOf(Lands_Joueur.Find(r => r.ID_Carte == cInstance.ID_Carte));
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Ajoute une carte à la main
        /// </summary>
        /// <param name="cInstance">Carte à ajouter</param>
        public void Add_Card(Land_Card cInstance)
        {
            int idx;
            idx = FindCard(cInstance);

            if (idx > -1)
            {
                Lands_Joueur[idx].NbLands_Total++;
                Lands_Joueur[idx].NbLands_Tapped++;
            }
            else
            {
                Lands_Joueur.Add(cInstance);
            }
            Refresh();
        }

        /// <summary>
        /// Affiche la carte en plus grand au survol sur la carte
        /// </summary>
        /// <param name="sender">Image survolé</param>
        /// <param name="e">Évènement</param>
        private void Show_Card(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // A CODER
        }
    }
}
