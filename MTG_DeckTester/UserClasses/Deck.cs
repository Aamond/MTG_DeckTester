using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Xml;
using System.Xml.Linq;

namespace MTG_DeckTester.UserClasses
{
    public class Deck
    {
        List<Card> _cards;
        string _auteurDeck;
        string _nomDeck;
        XDocument _xmlDeck;
        string _xmlDeck_Path;

        //Les attributs IG sont des variables utilisées pendant la partie
        int IG_nbCartes;

        /// <summary>
        /// Constructeur du deck
        /// </summary>
        /// <param name="nom">Nom du deck (= nom du fichier)</param>
        /// <param name="auteur"></param>
        public Deck(string nom, string auteur)
        {
            _nomDeck = nom;
            _auteurDeck = auteur;

            _xmlDeck_Path = ".decks/" + _nomDeck + ".xml";

            if (File.Exists(_xmlDeck_Path))
            {
                _xmlDeck = XDocument.Load(_xmlDeck_Path);
                var nodes = (from n in _xmlDeck.Descendants() where n.Name == "middle" select n).First();

                Console.WriteLine(nodes.Value.ToString());
                Console.ReadLine();
            }
        }

        /// APR - A TESTER
        /// <summary>
        /// Fonction de mélange du deck
        /// </summary>
        /// <param name="nbCartesAShuffle">Nombre de cartes à mélanger (dépendante de la taille initiale du deck ou du reste à mélanger)</param>
        public List<Card> Shuffle(List<Card> deckForShuffle)
        {
            List<Card> deck_suffled = new List<Card>();
            int nbCards = deckForShuffle.Count;
            Random rng = new Random();

            while (nbCards > 1)
            {
                nbCards--;
                int k = rng.Next(nbCards + 1);
                //T value = deck_suffled[k];
                deck_suffled[k] = deck_suffled[nbCards];
                //deck_suffled[nbCards] = value;
            }

            return deck_suffled;
        }
    }
}
