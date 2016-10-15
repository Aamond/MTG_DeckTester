using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_DeckTester.UserClasses
{
    public class Game
    {
        private static Game instance;

        private Player Joueur_1 { get; set; }
        private Player Joueur_2 { get; set; }
        private Deck Deck_Joueur_1 { get; set; }
        private Deck Deck_Joueur_2 { get; set; }

        /// <summary>
        /// Constructeur d'une partie (privé)
        /// </summary>
        /// <param name="J1">Player 1</param>
        /// <param name="J2">Player 2</param>
        /// <param name="deck_J1">Deck du joueur 1</param>
        /// <param name="deck_J2">Deck du joueur 2</param>
        private Game(Player J1, Player J2, Deck deck_J1, Deck deck_J2)
        {
            Joueur_1 = J1;
            Joueur_2 = J2;
            Deck_Joueur_1 = deck_J1;
            Deck_Joueur_2 = deck_J2;
        }

        /// <summary>
        /// Créer ou retourne l'instance d'une partie (Singleton)
        /// </summary>
        /// <param name="J1">Joueur 1</param>
        /// <param name="J2">Joueur 2</param>
        /// <param name="deck_J1">Deck du joueur 1</param>
        /// <param name="deck_J2">Deck du joueur 2</param>
        /// <returns></returns>
        public static Game GetInstance(Player J1, Player J2, Deck deck_J1, Deck deck_J2)
        {
            if (instance == null)
            {
                instance = new Game(J1, J2, deck_J1, deck_J2);
            }
            return instance;
        }
    }
}
