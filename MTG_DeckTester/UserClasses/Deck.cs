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
