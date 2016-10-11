using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MTG_DeckTester.UserClasses
{
    [Serializable]
    public class Card
    {
        [XmlAttribute()]
        string ID_Carte { get; set; }
        [XmlAttribute()]
        string Nom_Carte { get; set; }
        [XmlAttribute()]
        string MasterType { get; set; }
        [XmlAttribute()]
        bool EstLegendaire { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Code de la carte</param>
        /// <param name="nom">Nom de la carte</param>
        /// <param name="mastertype">Type principal de la carte</param>
        /// <param name="legendaire">1/True = Légendaire sinon pas légendaire</param>
        public Card(string id, string nom, string mastertype, bool legendaire)
        {
            ID_Carte = id;
            Nom_Carte = nom;
            MasterType = mastertype;
            EstLegendaire = legendaire;          
        }
    }

    
}