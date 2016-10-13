using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace MTG_DeckTester.UserClasses
{
    public class Tools
    {
        /// <summary>
        /// Fonction de gestion des erreurs (Log + Affichage dans une message box)
        /// </summary>
        /// <param name="ex">Erreur relevée</param>
        /// <param name="MethodName">Nom de la méthode en erreur</param>
        public void ParseError(Exception ex, string MethodName)
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
        private void ShowWarning(string message)
        {
            MessageBox.Show(ex.Message);
        }

        /// <summary>
        /// Fonction d'écriture d'un deck en XML
        /// </summary>
        /// <param name="dInstance">Instance du deck à écrire en XML</param>
        /// <param name="chemin">Chemin du fichier xml à écrire</param>
        public void WriteDeckXML(Deck dInstance, string chemin)
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
        public Deck ReadDeckXML(string chemin)
        {
            XmlSerializer reader = new XmlSerializer(typeof(Deck));
            using (FileStream input = File.OpenRead(chemin))
            {
                return reader.Deserialize(input) as Deck;
            }
        }

        /// <summary>
        /// Fonction de mélange d'un deck
        /// </summary>
        /// <param name="dInstance">Deck à mélanger</param>
        public void Shuffle(Deck dInstance)
        {
            Deck dTmp = new Deck();
            Random rnd = new Random();

            while(dInstance.Cartes.Count != 0)
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
        /// (On pioche la première, qu'on supprime du deck)
        /// </summary>
        /// <param name="dInstance">Deck dans lequel on pioche une carte</param>
        /// <returns>Carte piochée</returns>
        public Card Draw(Deck dInstance)
        {
            Card Carte_Piochee;

            Carte_Piochee = dInstance.Cartes[0];
            dInstance.Cartes.Remove(dInstance.Cartes[0]);

            return Carte_Piochee;
        } 
    }
}
