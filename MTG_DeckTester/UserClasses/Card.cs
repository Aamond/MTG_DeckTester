using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MTG_DeckTester.UserClasses
{
    [Serializable()]
    public class Card
    {
        public string ID_Carte { get; set; }
        public string Nom_Carte { get; set; }
        public string MasterType { get; set; }
        public bool EstLegendaire { get; set; }

        [XmlIgnore]
        public List<Card> AttachedCards { get; set; }
        [XmlIgnore]
        public bool IsLinked { get; set; }
        [XmlIgnore]
        public Marqueur Marqueur { get; set; }
        [XmlIgnore]
        public PlaceInGame EtatCarte { get; set; }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Card()
        {
            ID_Carte = null;
            Nom_Carte = null;
            MasterType = null;
            EstLegendaire = false;

            AttachedCards = new List<Card>();
            IsLinked = false;
            Marqueur = new Marqueur();

            EtatCarte = PlaceInGame.DECK;
        }

        /// <summary>
        /// Constructeur avec paramètres
        /// </summary>
        /// <param name="id">Identifiant de la carte (code.jpg)</param>
        /// <param name="nom">Nom de la carte</param>
        /// <param name="mastertype">Type principal de la carte</param>
        /// <param name="legendaire">Légendaire ou non</param>
        public Card(string id, string nom, string mastertype, bool legendaire)
        {
            ID_Carte = id;
            Nom_Carte = nom;
            MasterType = mastertype;
            EstLegendaire = legendaire;

            AttachedCards = new List<Card>();
            IsLinked = false;
            Marqueur = new Marqueur();

            EtatCarte = PlaceInGame.DECK;
        }
    }
}