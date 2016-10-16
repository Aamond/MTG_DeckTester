using System;

namespace MTG_DeckTester.UserClasses
{
    [Serializable()]
    public class Card
    {
        public string ID_Carte { get; set; }
        public string Nom_Carte { get; set; }
        public string MasterType { get; set; }
        public bool EstLegendaire { get; set; }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Card()
        {
            ID_Carte = null;
            Nom_Carte = null;
            MasterType = null;
            EstLegendaire = false;
        }

        /// <summary>
        /// Constructeur avec paramètres
        /// </summary>
        /// <param name="id">Identifiant de la carte (code.jpg)</param>
        /// <param name="nom">Nom de la carte</param>
        /// <param name="mastertype">Type principal de la carte</param>
        /// <param name="legendaire">Légendaire ou non</param>
        public Card(string id, string nom, string mastertype, bool legendaire)
        {
            ID_Carte = id;
            Nom_Carte = nom;
            MasterType = mastertype;
            EstLegendaire = legendaire;
        }
    }
}