using System.Collections.Generic;

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
    }
}
