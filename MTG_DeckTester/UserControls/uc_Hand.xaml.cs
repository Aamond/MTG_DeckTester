using MTG_DeckTester.UserClasses;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MTG_DeckTester.UserControls
{
    public partial class uc_Hand : UserControl
    {
        public List<Card> MainJoueur;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public uc_Hand()
        {            
            InitializeComponent();
            MainJoueur = new List<Card>();            
        }

        /// <summary>
        /// Raffraichis la visu sur la main
        /// </summary>
        private void Refresh()
        {
            int CptCartes;
            string NomImage;

            if (MainJoueur.Count < 9)
            {
                for (CptCartes = 0; CptCartes < MainJoueur.Count; CptCartes++)
                {
                    NomImage = "img_card_" + CptCartes;

                    foreach (var img in MainGrid_Hand.Children)
                    {
                        if (img is Image && (img as Image).Name == NomImage)
                        {
                            (img as Image).Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + MainJoueur[CptCartes].ID_Carte));
                            break;
                        }
                    }

                }
            }
            else
            {
                for (CptCartes = 0; CptCartes < 9; CptCartes++)
                {
                    NomImage = "img_card_" + CptCartes;
                    NomImage = "img_card_" + CptCartes;

                    foreach (var img in MainGrid_Hand.Children)
                    {
                        if (img is Image && (img as Image).Name == NomImage)
                        {
                            (img as Image).Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + MainJoueur[CptCartes].ID_Carte));
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Ajoute une carte à la main
        /// </summary>
        /// <param name="cInstance">Carte à ajouter</param>
        public void Add_Card(Card cInstance)
        {
            this.MainJoueur.Add(cInstance);
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
