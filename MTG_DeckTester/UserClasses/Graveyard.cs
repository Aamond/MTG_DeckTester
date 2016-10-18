using System.Collections.Generic;

namespace MTG_DeckTester.UserClasses
{
    public class Graveyard
    {
        public List<Card> Graveyard_Joueur;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Graveyard()
        {
            Graveyard_Joueur = new List<Card>();
        }
    }
}
