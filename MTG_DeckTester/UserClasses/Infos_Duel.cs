using System;

namespace MTG_DeckTester.UserClasses
{
    /// <summary>
    /// Classe qui sert uniquement à sérialize quelques infos du duel pour de futur duels (sauvegarde nom + ip des joueurs)
    /// </summary>
    [Serializable()]
    public class Infos_Duel
    {
        public Player Joueur1;
        public Player Joueur2;

        public string NomFichier;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Infos_Duel()
        {
            Joueur1 = new Player();
            Joueur2 = new Player();
            NomFichier = Tools.GetPath(ConfigKeys.DUELS) + "PARTIE_VIDE";
        }

        /// <summary>
        /// Constructeur avec paramètres
        /// </summary>
        /// <param name="j1">Joueur 1</param>
        /// <param name="j2">Joueur 2</param>
        public Infos_Duel(Player j1, Player j2)
        {
            Joueur1 = j1;
            Joueur2 = j2;
            NomFichier = Tools.GetPath(ConfigKeys.DUELS) + j1.Name + "_VS_" + j2.Name;
        }
    }
}
