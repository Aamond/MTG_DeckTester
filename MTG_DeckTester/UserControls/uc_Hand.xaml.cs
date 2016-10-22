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
        public int ID_Joueur {get; set;}

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
                            if (ID_Joueur == 1)
                            {
                                (img as Image).Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + MainJoueur[CptCartes].ID_Carte));
                                break;
                            }
                            else if (ID_Joueur == 2)
                            {
                                (img as Image).Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + "000000.jpg"));
                                break;
                            }
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
                            if (ID_Joueur == 1)
                            {
                                (img as Image).Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + MainJoueur[CptCartes].ID_Carte));
                                break;
                            }
                            else if (ID_Joueur == 2)
                            {
                                (img as Image).Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + "000000.jpg"));
                                break;
                            }
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
            MainJoueur.Add(cInstance);
            Refresh();
        }

        private void Show_Card(object sender, System.Windows.Input.MouseEventArgs e)
        {
            
        }
    }
}
