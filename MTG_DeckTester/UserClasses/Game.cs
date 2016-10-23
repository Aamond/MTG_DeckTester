using System.Collections.Generic;

namespace MTG_DeckTester.UserClasses
{
    public class Game
    {
        private static Game instance;

        private Player Joueur_1 { get; set; }
        private List<Card> J1_Main { get; set; }
        private Deck J1_Deck { get; set; }
        private Graveyard J1_Cimetiere { get; set; }
        private Exile J1_Exil { get; set; }

        private Player Joueur_2 { get; set; }
        private List<Card> J2_Main { get; set; }
        private Deck J2_Deck { get; set; }        
        private Graveyard J2_Cimetiere { get; set; }        
        private Exile J2_Exil { get; set; }

        /// <summary>
        /// Constructeur d'une partie (privé car Singleton)
        /// </summary>
        private Game()
        {
            Joueur_1 = new Player();
            J1_Main = new List<UserClasses.Card>();
            J1_Deck = new Deck();
            J1_Cimetiere = new UserClasses.Graveyard();

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

        /// <summary>
        /// Retourne le Joueur demandé (par ID de 1 à 2)
        /// </summary>
        /// <param name="ID_Player">ID du joueur</param>
        /// <returns>Joueur demandé</returns>
        public Player Get_Player(int ID_Player)
        {
            if (ID_Player == 1) { return Joueur_1; }
            else if (ID_Player == 2) { return Joueur_2; }
            else { return new Player(); }
        }

        /// <summary>
        /// Initialise un joueur (selon un ID de 1 à 2)
        /// </summary>
        /// <param name="ID_Player">ID du joueur à init</param>
        /// <param name="jInstance">Instance du joueur</param>
        public void Set_Player(int ID_Player, Player jInstance)
        {
            if (ID_Player == 1) { Joueur_1 = jInstance; }
            else if (ID_Player == 2) { Joueur_2 = jInstance; }            
        }

        /// <summary>
        /// Retourne le Deck du joueur demandé (par ID de 1 à 2)
        /// </summary>
        /// <param name="ID_Player">ID du joueur</param>
        /// <returns>Deck demandé</returns>
        public Deck Get_Deck(int ID_Player)
        {
            if (ID_Player == 1) { return Deck_Joueur_1; }
            else if (ID_Player == 2) { return Deck_Joueur_2; }
            else { return new Deck(); }
        }

        /// <summary>
        /// Initialise un deck d'un joueur (selon un ID de 1 à 2)
        /// </summary>
        /// <param name="ID_Player">ID du joueur à init</param>
        /// <param name="jInstance">Instance du deck</param>
        public void Set_Deck(int ID_Player, Deck dInstance)
        {
            if (ID_Player == 1) { Deck_Joueur_1 = dInstance; }
            else if (ID_Player == 2) { Deck_Joueur_2 = dInstance; }
        }
    }
}
