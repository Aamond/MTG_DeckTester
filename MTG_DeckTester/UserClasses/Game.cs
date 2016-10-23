using System.Collections.Generic;

namespace MTG_DeckTester.UserClasses
{
    public class Game
    {
        private static Game instance;

        public Player J1_Player { get; set; }
        public List<Card> J1_Main { get; set; }
        public Deck J1_Deck { get; set; }
        public List<Card> J1_Cimetiere { get; set; }
        public List<Card> J1_Exil { get; set; }

        public Player J2_Player { get; set; }
        public List<Card> J2_Main { get; set; }
        public Deck J2_Deck { get; set; }
        public List<Card> J2_Cimetiere { get; set; }
        public List<Card> J2_Exil { get; set; }

        /// <summary>
        /// Constructeur d'une partie (privé car Singleton)
        /// </summary>
        private Game()
        {
            J1_Player = new Player();
            J1_Main = new List<Card>();
            J1_Deck = new Deck();
            J1_Cimetiere = new List<Card>();
            J1_Exil = new List<Card>();

            J2_Player = new Player();
            J2_Main = new List<Card>();
            J2_Deck = new Deck();
            J2_Cimetiere = new List<Card>();
            J2_Exil = new List<Card>();
        }

        /// <summary>
        /// GetInstance de l'objet Game
        /// </summary>
        /// <returns>L'objet Game</returns>
        public static Game GetInstance()
        {
            if (instance == null)
            {
                instance = new Game();
            }
            return instance;
        }

    }
}
