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

        public uc_Hand()
        {
            int CptCartes;
            string NomImage;

            MainJoueur = new List<Card>();
            InitializeComponent();

            if (MainJoueur.Count < 9)
            {
                for (CptCartes = 0; CptCartes < MainJoueur.Count; CptCartes++)
                {
                    NomImage = "img_card_" + CptCartes;

                    foreach (var img in Grid_Principale.Children)
                    {
                        if (img is Image && (img as Image).Name == NomImage)
                        {
                            (img as Image).Source = new BitmapImage(new Uri(Tools.GetPath("cardsDirectory") + MainJoueur[CptCartes].ID_Carte));
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

                    foreach (var img in Grid_Principale.Children)
                    {
                        if (img is Image && (img as Image).Name == NomImage)
                        {
                            (img as Image).Source = new BitmapImage(new Uri(Tools.GetPath("cardsDirectory") + MainJoueur[CptCartes].ID_Carte));
                            break;
                        }
                    }
                }
            }
        }
    }
}
