using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_DeckTester.UserClasses
{
    public class Card
    {
        string _id;
        string _nom;
        string _masterType;
        bool _estLegendaire;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Code de la carte</param>
        /// <param name="nom">Nom de la carte</param>
        /// <param name="mastertype">Type principal de la carte</param>
        /// <param name="legendaire">1/True = Légendaire sinon pas légendaire</param>
        public Card(string id, string nom, string mastertype, int legendaire)
        {
            _id = id;
            _nom = nom;
            _masterType = mastertype;

            if (legendaire == 1)
            {
                _estLegendaire = true;
            }
            else
            {
                _estLegendaire = false;
            }            
        }
    }

    
}