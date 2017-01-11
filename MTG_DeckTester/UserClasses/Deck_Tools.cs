using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace MTG_DeckTester.UserClasses
{
    public static class Deck_Tools
    {
        /// <summary>
        /// Fonction de mélange d'un deck
        /// </summary>
        /// <param name="dInstance">Deck à mélanger</param>
        public static void Shuffle(Deck dInstance)
        {
            Deck dTmp = new Deck();
            Random rnd = new Random();

            // This will filter out the list of ints that are > than 7, Where returns an
            // IEnumerable<T> so a call to ToList is required to convert back to a List<T>.
            deck_list = myList.Where(x => x > 7).ToList();

            dInstance.Cartes.Where(x => )

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
        public static void Draw(Deck dInstance)
        {
            Card Carte_Piochee;

            Carte_Piochee = dInstance.Cartes[0];
            dInstance.Cartes.Remove(dInstance.Cartes[0]);
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
            int cpt;

            XmlSerializer reader = new XmlSerializer(typeof(Deck));
            using (FileStream input = File.OpenRead(chemin))
            {
                for (cpt = 0; cpt < (reader.Deserialize(input) as Deck).Cartes.Count; cpt++)
                {
                    (reader.Deserialize(input) as Deck).Cartes[cpt].EtatCarte = PlaceInGame.DECK;
                }

                return reader.Deserialize(input) as Deck;
            }
        }
    }
}
