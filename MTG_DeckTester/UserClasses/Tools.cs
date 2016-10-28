using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace MTG_DeckTester.UserClasses
{
    public static class Tools
    {
        //Instance de la partie - GLOBALE
        public static Game CurrentGame = Game.GetInstance();

        /// <summary>
        /// Fonction de gestion des erreurs (Log + Affichage dans une message box)
        /// </summary>
        /// <param name="ex">Erreur relevée</param>
        /// <param name="MethodName">Nom de la méthode en erreur</param>
        public static void ParseError(Exception ex, string MethodName)
        {
            try
            {
                string ErrorPath = System.IO.Path.GetTempPath() + @"\MTG_DeckTester\Errors\";
                if (!Directory.Exists(ErrorPath))
                    Directory.CreateDirectory(ErrorPath);

                if (!File.Exists(ErrorPath + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + ".txt"))
                {
                    using (System.IO.FileStream fs = new FileStream(ErrorPath + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + ".txt", FileMode.Create))
                    {
                        byte[] Header = System.Text.Encoding.UTF8.GetBytes("                                                                 ***** " + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + " *****");
                        fs.Write(Header, 0, Header.Length);
                    }
                }

                using (FileStream fs = new FileStream(ErrorPath + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + ".txt", FileMode.Append))
                {
                    byte[] Content = System.Text.Encoding.UTF8.GetBytes("\r\n\r\n   *** " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " Method Name: " + MethodName + ",  Erreur =>     ** " + ex.Message + "\r\n                  InnerException: " + ((ex.InnerException != null) ? ex.InnerException.Message : "No Inner Exception") + " **");
                    fs.Write(Content, 0, Content.Length);
                }

                ShowWarning(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Affiche simplement l'erreur (évolution possible --> créer une fenêtre dédiée et afficher le message dedans)
        /// </summary>
        /// <param name="message">Message d'avertissement/erreur à afficher</param>
        private static void ShowWarning(string message)
        {
            MessageBox.Show(message);
        }

        /// <summary>
        /// Fonction d'écriture d'un deck en XML
        /// </summary>
        /// <param name="dInstance">Instance du deck à écrire en XML</param>
        /// <param name="chemin">Chemin du fichier xml à écrire</param>
        public static void WriteDeckXML(Deck dInstance, string chemin)
        {
            XmlSerializer writer = new XmlSerializer(typeof(Deck));
            using (FileStream file = File.OpenWrite(chemin))
            {
                writer.Serialize(file, dInstance);
            }
        }

        /// <summary>
        /// Fonction de lecture d'un fichier XML, retourne l'objet deck rempli associé
        /// </summary>
        /// <param name="chemin">Chemin du fichier XML à lire</param>
        /// <returns>Objet deck rempli selon la lecture du fichier</returns>
        public static Deck ReadDeckXML(string chemin)
        {
            XmlSerializer reader = new XmlSerializer(typeof(Deck));
            using (FileStream input = File.OpenRead(chemin))
            {
                return reader.Deserialize(input) as Deck;
            }
        }

        /// <summary>
        /// Fonction d'écriture d'un duel en XML
        /// </summary>
        /// <param name="dInstance">Instance du duel à écrire en XML</param>
        /// <param name="chemin">Chemin du fichier xml à écrire</param>
        public static void WriteInfoDuellXML(Infos_Duel dInstance, string chemin)
        {
            XmlSerializer writer = new XmlSerializer(typeof(Infos_Duel));
            using (FileStream file = File.OpenWrite(chemin))
            {
                writer.Serialize(file, dInstance);
            }
        }

        /// <summary>
        /// Fonction de lecture d'un fichier XML, retourne l'objet duel rempli associé
        /// </summary>
        /// <param name="chemin">Chemin du fichier XML à lire</param>
        /// <returns>Objet duel rempli selon la lecture du fichier</returns>
        public static Infos_Duel ReadInfoDuelXML(string chemin)
        {
            XmlSerializer reader = new XmlSerializer(typeof(Infos_Duel));
            using (FileStream input = File.OpenRead(chemin))
            {
                return reader.Deserialize(input) as Infos_Duel;
            }
        }

        /// <summary>
        /// Fonction de mélange d'un deck
        /// </summary>
        /// <param name="dInstance">Deck à mélanger</param>
        public static void Shuffle(Deck dInstance)
        {
            Deck dTmp = new Deck();
            Random rnd = new Random();

            while (dInstance.Cartes.Count != 0)
            {
                //On ajoute à notre deck de travail une carte aléatoire du deck à mélanger
                dTmp.Cartes.Add(dInstance.Cartes[rnd.Next(dInstance.Cartes.Count)]);

                // On supprime ensuite la carte du deck à mélanger
                dInstance.Cartes.Remove(dInstance.Cartes[rnd.Next(dInstance.Cartes.Count)]);
            }

            //On copie le deck de travail dans le deck à mélanger (et il est mélangé du coup)
            dInstance.Cartes = dTmp.Cartes;
        }

        /// <summary>
        /// Fonction de pioche
        /// (On pioche la première, la carte à l'indice 0, qu'on supprime du deck)
        /// </summary>
        /// <param name="dInstance">Deck dans lequel on pioche une carte</param>
        /// <returns>Carte piochée</returns>
        public static Card Draw(Deck dInstance)
        {
            Card Carte_Piochee;

            Carte_Piochee = dInstance.Cartes[0];
            dInstance.Cartes.Remove(dInstance.Cartes[0]);

            return Carte_Piochee;
        }

        /// <summary>
        /// Fonction d'obtention d'un chemin tiré du App.config
        /// </summary>
        /// <param name="key">Clé</param>
        /// <returns>Chemin associé</returns>
        public static string GetPath(ConfigKeys key)
        {
            string res;

            switch (key)
            {
                case ConfigKeys.IMG:
                    res = System.Configuration.ConfigurationManager.AppSettings["imgDirectoryPath"];
                    break;

                case ConfigKeys.PLAYERS:
                    res = System.Configuration.ConfigurationManager.AppSettings["playerDirectory"];
                    break;

                case ConfigKeys.DECK_COLOR:
                    res = System.Configuration.ConfigurationManager.AppSettings["deckColorsDirectory"];
                    break;

                case ConfigKeys.DECKS:
                    res = System.Configuration.ConfigurationManager.AppSettings["decksDirectory"];
                    break;

                case ConfigKeys.DUELS:
                    res = System.Configuration.ConfigurationManager.AppSettings["duelsDirectory"];
                    break;

                case ConfigKeys.CARDS:
                    res = System.Configuration.ConfigurationManager.AppSettings["cardsDirectory"];
                    break;

                default:
                    res = "";
                    break;
            }

            return res;

        }

        /// <summary>
        /// A partir d'une string, retourne le code lié au type de carte
        /// </summary>
        /// <param name="type">String à convertir en code</param>
        /// <returns>Code associé</returns>
        public static MasterType GetMasterType(string type)
        {
            MasterType res;

            switch (type)
            {
                case "Terrain":
                case "Terrain de base":
                    res = MasterType.TERRAIN;
                    break;

                case "Créature":
                case "Creature":
                    res = MasterType.CREATURE;
                    break;

                case "Artefact":
                    res = MasterType.ARTEFACT;
                    break;

                case "Enchantement":
                    res = MasterType.ENCHANTEMENT;
                    break;

                case "Éphémère":
                case "Ephémère":
                case "Ephemere":
                    res = MasterType.EPHEMERE;
                    break;

                case "Rituel":
                    res = MasterType.RITUEL;
                    break;

                default:
                    res = MasterType.UNDEFINED;
                    break;
            }
            return res;
        }

        /// <summary>
        /// Retourne l'indice de la grille où afficher la carte
        /// </summary>
        /// <param name="ListCount">List.Count des cartes de la collection</param>
        /// <returns>Indice du prochain endroit où afficher la carte</returns>
        public static int GetNextPlaceCard(int indiceCarte)
        {
            switch (indiceCarte)
            {
                //7,8,6,9,5,10,4,11,3,12,2,13,1,14,0
                case 0:
                    return 7;
                case 1:
                    return 8;
                case 2:
                    return 6;
                case 3:
                    return 9;
                case 4:
                    return 5;
                case 5:
                    return 10;
                case 6:
                    return 4;
                case 7:
                    return 11;
                case 8:
                    return 3;
                case 9:
                    return 12;
                case 10:
                    return 2;
                case 11:
                    return 13;
                case 12:
                    return 1;
                case 13:
                    return 14;
                case 14:
                    return 0;
                default:
                    return -1;
            }
        }
    }

    /// <summary>
    /// Classe représentant un marqueur sur une carte
    /// </summary>
    public class Marqueur
    {
        public string MarqueurName { get; set; }
        public int NbMarqueur { get; set; }

        /// <summary>
        /// Constructeur par défaut d'un marqueur
        /// </summary>
        public Marqueur()
        {
            MarqueurName = "";
            NbMarqueur = 0;
        }

        /// <summary>
        /// Constructeur avec paramètres
        /// </summary>
        /// <param name="name">Nom du marqueur</param>
        /// <param name="nb">Nombre de marqueur</param>
        public Marqueur(string name, int nb)
        {
            MarqueurName = name;
            NbMarqueur = nb;
        }
    }

    public enum ConfigKeys
    { IMG = 0, PLAYERS = 1, DECKS = 2, CARDS = 3, DECK_COLOR = 4, DUELS = 5 };

    public enum MasterType
    { TERRAIN = 0, CREATURE = 1, ARTEFACT = 2, ENCHANTEMENT = 3, EPHEMERE = 4, RITUEL = 5, UNDEFINED = 9 };
}
