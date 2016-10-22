namespace MTG_DeckTester.UserClasses
{
    public class Visionneuse
    {
        public Card CarteVisionnee { get; set; }
        public bool IsVisible { get; set; }

        /// <summary>
        /// Constructeur par défaut de la visionneuse
        /// </summary>
        public Visionneuse()
        {
            CarteVisionnee = new Card();
            IsVisible = false;
        }

        /// <summary>
        /// Ajoute une carte passée en paramètre dans la visionneuse
        /// </summary>
        /// <param name="cInstance">Carte à montrer</param>
        public void ShowCard(Card cInstance)
        {
            CarteVisionnee = cInstance;
            IsVisible = true;
        }

        /// <summary>
        /// Fonction d'écrasement de la visionneuse (à appeler en sortant du MouseOver d'une carte)
        /// </summary>
        public void EraseCard()
        {
            CarteVisionnee = null;
            IsVisible = false;
        }
    }
}
