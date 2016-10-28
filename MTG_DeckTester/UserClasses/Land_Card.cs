﻿using System.Collections.Generic;

namespace MTG_DeckTester.UserClasses
{
    public class Land_Card : Card
    {
        public List<Card> AttachedCards;
        public bool IsLinked;
        public int NbLands_Total;
        public int NbLands_Tapped;
        
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Land_Card()
        {
            AttachedCards = new List<Card>();
            IsLinked = false;
            NbLands_Total = 1;
            NbLands_Tapped = 0;
        }

        public Land_Card(string id, string nom, string mastertype, bool legendaire)
        {
            ID_Carte = id;
            Nom_Carte = nom;
            MasterType = mastertype;
            EstLegendaire = legendaire;

            AttachedCards = new List<Card>();
            IsLinked = false;
            NbLands_Total = 1;
            NbLands_Tapped = 0;
        }
    }
}
