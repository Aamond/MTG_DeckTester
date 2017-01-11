namespace MTG_DeckTester.UserClasses
{
    /// <summary>
    /// Classe représentant un marqueur sur une carte
    /// </summary>
    public class Marqueur
    {
        public string MarqueurName { get; set; }
        public int NbMarqueur { get; set; }

        /// <summary>
        /// Constructeur par défaut d'un marqueur
        /// </summary>
        public Marqueur()
        {
            MarqueurName = "";
            NbMarqueur = 0;
        }

        /// <summary>
        /// Constructeur avec paramètres
        /// </summary>
        /// <param name="name">Nom du marqueur</param>
        /// <param name="nb">Nombre de marqueur</param>
        public Marqueur(string name, int nb)
        {
            MarqueurName = name;
            NbMarqueur = nb;
        }
    }
}
