using System.Collections.Generic;

namespace MTG_DeckTester.UserClasses
{
    public class Exile
    {
        public List<Card> Exile_Joueur;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Exile()
        {
            Exile_Joueur = new List<Card>();
        }
    }
}
