using System;
using System.Collections.Generic;

namespace MTG_DeckTester.UserClasses
{
    [Serializable()]
    public class Deck
    {
        public List<Card> Cartes { get; set; }
        public string NomDeck;
        public string AuteurDeck;
        public string CouleurDeck;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Deck()
        {
            Cartes = new List<Card>();
            NomDeck = "";
            AuteurDeck = "";
            CouleurDeck = "";
        }
    }
}
