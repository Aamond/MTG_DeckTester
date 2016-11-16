using MTG_DeckTester.UserClasses;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MTG_DeckTester.UserControls
{
    /// <summary>
    /// Interaction logic for uc_Board_Deck.xaml
    /// </summary>
    public partial class uc_Board_Deck : UserControl
    {
        public int ID_Joueur;

        /// <summary>
        /// Constructeur du UserControl Deck/Cimetiere/Exil
        /// </summary>
        public uc_Board_Deck()
        {
            InitializeComponent();

            img_deck_card.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + "000000.jpg", UriKind.RelativeOrAbsolute));
            img_graveyard_card.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + "000000.jpg", UriKind.RelativeOrAbsolute));
            img_exile_card.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + "000000.jpg", UriKind.RelativeOrAbsolute));
        }

        /// <summary>
        /// Raffraichis l'affichage du UserControl
        /// </summary>
        public void Refresh()
        {
            //Mise à jour des ToolTip des listes
            if(ID_Joueur == 1)
            {
                //--DECK--
                if (Tools.CurrentGame.J1_Deck.Cartes.Count == 0)
                {
                    Lbl_deck_event.ToolTip = "Il n'y a plus de cartes dans le deck !";
                }
                else
                {
                    Lbl_deck_event.ToolTip = "Il reste " + Tools.CurrentGame.J1_Deck.Cartes.Count + " carte(s) dans le deck";
                }

                //--CIMETIERE--
                if (Tools.CurrentGame.J1_Cimetiere.Count == 0)
                {
                    Lbl_graveyard_event.ToolTip = "Aucune carte dans le cimetière !";
                }
                else
                {
                    Lbl_graveyard_event.ToolTip = "Il y a " + Tools.CurrentGame.J1_Cimetiere.Count + " carte(s) dans le cimetière";
                }

                //--EXIL--
                if (Tools.CurrentGame.J1_Exil.Count == 0)
                {
                    Lbl_exil_event.ToolTip = "Aucune carte dans l'exil !";
                }
                else
                {
                    Lbl_exil_event.ToolTip = "Il y a " + Tools.CurrentGame.J1_Exil.Count + " carte(s) dans l'exil";
                }
            }
            else if(ID_Joueur == 2)
            {
                //--DECK--
                if (Tools.CurrentGame.J2_Deck.Cartes.Count == 0)
                {
                    Lbl_deck_event.ToolTip = "Il n'y a plus de cartes dans le deck !";
                }
                else
                {
                    Lbl_deck_event.ToolTip = "Il reste " + Tools.CurrentGame.J2_Deck.Cartes.Count + " carte(s) dans le deck";
                }

                //--CIMETIERE--
                if (Tools.CurrentGame.J2_Cimetiere.Count == 0)
                {
                    Lbl_graveyard_event.ToolTip = "Aucune carte dans le cimetière !";
                }
                else
                {
                    Lbl_graveyard_event.ToolTip = "Il y a " + Tools.CurrentGame.J2_Cimetiere.Count + " carte(s) dans le cimetière";
                }

                //--EXIL--
                if (Tools.CurrentGame.J2_Exil.Count == 0)
                {
                    Lbl_exil_event.ToolTip = "Aucune carte dans l'exil !";
                }
                else
                {
                    Lbl_exil_event.ToolTip = "Il y a " + Tools.CurrentGame.J2_Exil.Count + " carte(s) dans l'exil";
                }
            }
        }

        /// <summary>
        /// Fonction de pioche dans un deck
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void D_DrawCard(object sender, System.Windows.RoutedEventArgs e)
        {
            if(ID_Joueur == 1)
            {
                Tools.CurrentGame.J1_Main.Add(Tools.Draw(Tools.CurrentGame.J1_Deck));
                Refresh();
                Tools.CurrentMainWindow.uc_Hands_Refresh(ID_Joueur);
            }
        }

        /// <summary>
        /// Fonction de recherche dans un deck (ouverture d'une page type liste de carte)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void D_SeekCard(object sender, System.Windows.RoutedEventArgs e)
        {
            if(ID_Joueur == 1)
            {
                SearchCard sc = new SearchCard(Tools.CurrentGame.J1_Deck.Cartes);
                sc.ShowDialog();
            }
            else if(ID_Joueur == 2)
            {
                SearchCard sc = new SearchCard(Tools.CurrentGame.J2_Deck.Cartes);
                sc.ShowDialog();
            }            
        }

        /// <summary>
        /// Fonction permettant de mettre la prochaine carte du deck dans le cimetière
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void D_PutInGraveyard(object sender, System.Windows.RoutedEventArgs e)
        {
            if(ID_Joueur == 1)
            {
                Tools.CurrentGame.J1_Cimetiere.Add(Tools.Draw(Tools.CurrentGame.J1_Deck));
                Refresh();
            }
        }

        /// <summary>
        /// Fonction permettant de mettre la prochaine carte du deck dans l'Exil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void D_PutInExile(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ID_Joueur == 1)
            {
                Tools.CurrentGame.J1_Exil.Add(Tools.Draw(Tools.CurrentGame.J1_Deck));
                Refresh();
            }
        }

        /// <summary>
        /// Révèle la carte du dessus du deck (pour les decks type celui de Yoan)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void D_ShowNextCard(object sender, System.Windows.RoutedEventArgs e)
        {
            if(ID_Joueur == 1)
            {
                if (img_deck_card.Source == new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + "000000.jpg", UriKind.RelativeOrAbsolute)))
                {
                    img_deck_card.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + Tools.CurrentGame.J1_Deck.Cartes[0].ID_Carte, UriKind.RelativeOrAbsolute));
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Masque la carte du dessus du deck (pour les decks type celui de Yoan)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void D_HideNextCard(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ID_Joueur == 1)
            {
                if (img_deck_card.Source != new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + "000000.jpg", UriKind.RelativeOrAbsolute)))
                {
                    img_deck_card.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + "000000.jpg", UriKind.RelativeOrAbsolute));
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Fonction de recherche d'une carte dans un cimetière
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void C_SeekCard(object sender, System.Windows.RoutedEventArgs e)
        {
            //A implémenter
        }

        /// <summary>
        /// Fonction permettant de mettre la prochaine carte du cimetière dans l'exil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void C_PutInExile(object sender, System.Windows.RoutedEventArgs e)
        {
            if(ID_Joueur == 1)
            {
                Tools.CurrentGame.J1_Exil.Add(Tools.CurrentGame.J1_Cimetiere[0]);
                Tools.CurrentGame.J1_Cimetiere.Remove(Tools.CurrentGame.J1_Cimetiere[0]);
                Refresh();
            }
        }

        /// <summary>
        /// Fonction de recherche d'une carte dans l'exil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void E_SeekCard(object sender, System.Windows.RoutedEventArgs e)
        {
            //A implémenter
        }
    }
}
