namespace MTG_DeckTester.UserClasses
{
    public class Player
    {
        public string Name { get; set; }
        public string IP { get; set; }

        /// <summary>
        /// Crée une instance d'un joueur (sans paramètres)
        /// </summary>
        public Player()
        {
            Name = "player";
            IP = "127.0.0.1";
        }

        /// <summary>
        /// Crée une instance d'un joueur (avec paramètres)
        /// </summary>
        /// <param name="username">Nom du joueur</param>
        /// <param name="ip">IP du joueur</param>
        public Player(string username, string ip)
        {
            Name = username;
            IP = ip;
        }
    }
}
