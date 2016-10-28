using MTG_DeckTester.UserClasses;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MTG_DeckTester.UserControls
{
    public partial class uc_Hand : UserControl
    {
        public int ID_Joueur;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public uc_Hand()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Raffraichis la visu sur la main
        /// </summary>
        public void Refresh()
        {
            int CptCartes;
            string NomImage;

            //Réinit des images
            for (CptCartes = 0; CptCartes < 9; CptCartes++)
            {
                NomImage = "img_card_" + CptCartes;

                foreach (var img in MainGrid_Hand.Children)
                {
                    if (img is Image && (img as Image).Name == NomImage)
                    {
                        (img as Image).Source = new BitmapImage();
                        break;
                    }
                }
            }

            if (ID_Joueur == 1)
            {
                if (Tools.CurrentGame.J1_Main.Count < 9)
                {
                    for (CptCartes = 0; CptCartes < Tools.CurrentGame.J1_Main.Count; CptCartes++)
                    {
                        NomImage = "img_card_" + CptCartes;

                        foreach (var img in MainGrid_Hand.Children)
                        {
                            if (img is Image && (img as Image).Name == NomImage)
                            {
                                if (ID_Joueur == 1)
                                {
                                    (img as Image).Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + Tools.CurrentGame.J1_Main[CptCartes].ID_Carte));
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
                                    (img as Image).Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + Tools.CurrentGame.J1_Main[CptCartes].ID_Carte));
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
            else if (ID_Joueur == 2)
            {

                if (Tools.CurrentGame.J2_Main.Count < 9)
                {
                    for (CptCartes = 0; CptCartes < Tools.CurrentGame.J2_Main.Count; CptCartes++)
                    {
                        NomImage = "img_card_" + CptCartes;

                        foreach (var img in MainGrid_Hand.Children)
                        {
                            if (img is Image && (img as Image).Name == NomImage)
                            {
                                (img as Image).Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + "000000.jpg"));
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
                                (img as Image).Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + "000000.jpg"));
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Fonction de jeu d'une carte (posée à différents endroits selon le type de la carte)
        /// </summary>
        /// <param name="sender">Image qui lève l'évènement</param>
        /// <param name="e">Clic</param>
        private void PlayCard(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MasterType typecard;
            int indice_card;
            Creature_Card creaInstance;
            Land_Card landInstance;
            Special_Card specInstance;

            if (e.ClickCount == 2)
            {
                //On gère ici uniquement les évènements du joueur 1
                //Les évènements du joueur 2 seront gérés par le module de communication
                if (ID_Joueur == 1)
                {
                    indice_card = Int32.Parse((sender as Image).Name.Substring(9, 1));
                    typecard = Tools.GetMasterType((Tools.CurrentGame.J1_Main[indice_card].MasterType));

                    switch (typecard)
                    {
                        case MasterType.CREATURE:

                            //Construction de la carte créature à partir de la carte jouée
                            creaInstance = new Creature_Card(Tools.CurrentGame.J1_Main[indice_card].ID_Carte, Tools.CurrentGame.J1_Main[indice_card].Nom_Carte, Tools.CurrentGame.J1_Main[indice_card].MasterType, Tools.CurrentGame.J1_Main[indice_card].EstLegendaire);
                            Tools.CurrentGame.J1_Board_Creatures.Add(creaInstance);
                            Tools.CurrentGame.J1_Main.Remove(Tools.CurrentGame.J1_Main[indice_card]);
                            break;

                        case MasterType.TERRAIN:

                            //Construction de la carte terrain à partir de la carte jouée
                            landInstance = new Land_Card(Tools.CurrentGame.J1_Main[indice_card].ID_Carte, Tools.CurrentGame.J1_Main[indice_card].Nom_Carte, Tools.CurrentGame.J1_Main[indice_card].MasterType, Tools.CurrentGame.J1_Main[indice_card].EstLegendaire);
                            Tools.CurrentGame.J1_Board_Lands.Add(landInstance);
                            Tools.CurrentGame.J1_Main.Remove(Tools.CurrentGame.J1_Main[indice_card]);
                            break;

                        case MasterType.ENCHANTEMENT:
                        case MasterType.ARTEFACT:

                            //Construction de la carte speciales à partir de la carte jouée
                            specInstance = new Special_Card(Tools.CurrentGame.J1_Main[indice_card].ID_Carte, Tools.CurrentGame.J1_Main[indice_card].Nom_Carte, Tools.CurrentGame.J1_Main[indice_card].MasterType, Tools.CurrentGame.J1_Main[indice_card].EstLegendaire);
                            Tools.CurrentGame.J1_Board_Specials.Add(specInstance);
                            Tools.CurrentGame.J1_Main.Remove(Tools.CurrentGame.J1_Main[indice_card]);
                            break;

                        case MasterType.RITUEL:
                        case MasterType.EPHEMERE:

                            //Affichage du sort joué en gros plan au milieu, un peu au dessus de la main
                            img_Spell.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + Tools.CurrentGame.J1_Main[indice_card].ID_Carte));
                            Tools.CurrentGame.J1_Cimetiere.Add(Tools.CurrentGame.J1_Main[indice_card]);
                            Tools.CurrentGame.J1_Main.Remove(Tools.CurrentGame.J1_Main[indice_card]);
                            break;

                        default:
                            break;
                    }
                    Refresh();
                }
            }
        }

        private void Show_Card(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // A voir comment faire - Grosse image au milieu ?
        }

        /// <summary>
        /// Réinitialise l'image du sort d'éphémère ou de rituel lancé
        /// </summary>
        /// <param name="sender">Image img_Spell</param>
        /// <param name="e">Double-clic</param>
        private void End_Spell(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2)
            {
                img_Spell.Source = new BitmapImage();
            }
        }
    }
}
