using System.Collections.Generic;

namespace MTG_DeckTester.UserClasses
{
    public class Special_Card : Card
    {
        public List<Card> AttachedCards;
        public bool IsLinked;
        public int Attack;
        public int Health;
        public Marqueur Marqueur;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Special_Card()
        {
            AttachedCards = new List<Card>();
            IsLinked = false;
            Attack = 0;
            Health = 0;
            Marqueur = new Marqueur();
        }

        public Special_Card(string id, string nom, string mastertype, bool legendaire)
        {
            ID_Carte = id;
            Nom_Carte = nom;
            MasterType = mastertype;
            EstLegendaire = legendaire;

            AttachedCards = new List<Card>();
            IsLinked = false;
            Attack = 0;
            Health = 0;
            Marqueur = new Marqueur();
        }
    }
}
