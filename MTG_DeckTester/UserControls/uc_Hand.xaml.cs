using MTG_DeckTester.UserClasses;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MTG_DeckTester.UserControls
{
    public partial class uc_Hand : UserControl
    {
        public List<Card> MainJoueur;
        public int ID_Joueur {get; set;}

        private uc_VisionneuseCarte ViewerCard;

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

            //Réinit des images
            for (CptCartes = 0; CptCartes < MainJoueur.Count; CptCartes++)
            {
                NomImage = "img_card_" + CptCartes;

                foreach (var img in MainGrid_Hand.Children)
                {
                    if (img is Image && (img as Image).Name == NomImage)
                    {
                        if (ID_Joueur == 1)
                        {
                            (img as Image).Source = new BitmapImage();
                            break;
                        }
                        else if (ID_Joueur == 2)
                        {
                            (img as Image).Source = new BitmapImage();
                            break;
                        }
                    }
                }
            }

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

        /// <summary>
        /// Au survol d'une image, envoie la carte 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Show_Card(object sender, MouseEventArgs e)
        {            
            ViewerCard = new uc_VisionneuseCarte((sender as Image));
            ViewerCard.img_card = (sender as Image);
            ViewerCard.Visibility = System.Windows.Visibility.Visible;
        }

        /// <summary>
        /// Fonction de jeu d'une carte
        /// </summary>
        /// <param name="sender">Image</param>
        /// <param name="e">Evenement</param>
        private void PlayCard(object sender, MouseButtonEventArgs e)
        {
            int indice_image;
            MasterType Type;

            //Si double-clic sur la carte
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2 && (sender as Image).Source != null)
            {
                indice_image = int.Parse((sender as Image).Name.Substring(9, 1));
                Type = Tools.GetMasterType(MainJoueur[indice_image].MasterType);

                switch (Type)
                {
                    case MasterType.TERRAIN:
                        
                        MainJoueur.Remove(MainJoueur[indice_image]);
                        Refresh();
                        break;

                    case MasterType.CREATURE:

                        MainJoueur.Remove(MainJoueur[indice_image]);
                        Refresh();
                        break;

                    case MasterType.ARTEFACT:
                    case MasterType.ENCHANTEMENT:

                        MainJoueur.Remove(MainJoueur[indice_image]);
                        Refresh();
                        break;

                    case MasterType.EPHEMERE:
                    case MasterType.RITUEL:

                        MainJoueur.Remove(MainJoueur[indice_image]);
                        Refresh();
                        break;

                    case MasterType.UNDEFINED:
                        break;
                }                                
            }
        }

   
    }
}
