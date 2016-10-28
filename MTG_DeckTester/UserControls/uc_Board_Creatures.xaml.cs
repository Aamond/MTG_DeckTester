using MTG_DeckTester.UserClasses;
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
            string NomLbl_Marqueurs;
            string NomLbl_Background;

            Init_uc_Board_Creatures();

            if(ID_Joueur == 1)
            {
                for (CptCartes = 0; CptCartes < Tools.CurrentGame.J1_Board_Creatures.Count; CptCartes++)
                {
                    NomImage = "img_Creature_card_" + Tools.GetNextPlaceCard(CptCartes);
                    NomLbl_Marqueurs = "lbl_Creature_Marks_" + CptCartes;
                    NomLbl_Background = "IsLinked_" + CptCartes;

                    //Mise à jour des éléments du UserControle
                    foreach (var tmp in MainGrid_Creatures.Children)
                    {
                        //Si c'est une image, on set l'image selon la carte associé
                        if (tmp is Image && (tmp as Image).Name == NomImage)
                        {
                            (tmp as Image).Source = new BitmapImage(new System.Uri(Tools.GetPath(ConfigKeys.CARDS) + Tools.CurrentGame.J1_Board_Creatures[CptCartes].ID_Carte));
                        }

                        //Si marqueur, on indique cela dans le Label
                        if (tmp is Label && (tmp as Label).Name == NomLbl_Marqueurs)
                        {
                            if (Tools.CurrentGame.J1_Board_Creatures[CptCartes].Marqueur.NbMarqueur == 0)
                            {
                                (tmp as Label).Visibility = Visibility.Collapsed;
                            }
                            else
                            {
                                (tmp as Label).Content = "+" + Tools.CurrentGame.J1_Board_Creatures[CptCartes].Marqueur.NbMarqueur.ToString() + "/ +" + Tools.CurrentGame.J1_Board_Creatures[CptCartes].Marqueur.NbMarqueur.ToString();
                                (tmp as Label).Visibility = Visibility.Visible;
                            }
                        }
                    }
                }
            }
            else if(ID_Joueur == 2)
            {
                for (CptCartes = 0; CptCartes < Tools.CurrentGame.J2_Board_Creatures.Count; CptCartes++)
                {
                    NomImage = "img_Creature_card_" + CptCartes;
                    NomLbl_Marqueurs = "lbl_Creature_Marks_" + CptCartes;
                    NomLbl_Background = "IsLinked_" + CptCartes;

                    //Mise à jour des éléments du UserControle
                    foreach (var tmp in MainGrid_Creatures.Children)
                    {
                        //Si c'est une image, on set l'image selon la carte associée
                        if (tmp is Image && (tmp as Image).Name == NomImage)
                        {
                            (tmp as Image).Source = new BitmapImage(new System.Uri(Tools.GetPath(ConfigKeys.CARDS) + Tools.CurrentGame.J2_Board_Creatures[CptCartes].ID_Carte));
                        }

                        //Si la créature à des marqueurs, on indique cela dans le Label
                        if (tmp is Label && (tmp as Label).Name == NomLbl_Marqueurs)
                        {
                            if (Tools.CurrentGame.J2_Board_Creatures[CptCartes].Marqueur.NbMarqueur == 0)
                            {
                                (tmp as Label).Visibility = Visibility.Collapsed;
                            }
                            else
                            {
                                (tmp as Label).Content = "+" + Tools.CurrentGame.J2_Board_Creatures[CptCartes].Marqueur.NbMarqueur.ToString() + "/ +" + Tools.CurrentGame.J2_Board_Creatures[CptCartes].Marqueur.NbMarqueur.ToString();
                                (tmp as Label).Visibility = Visibility.Visible;
                            }
                        }
                    }
                }
            }            
        }
    }
}
