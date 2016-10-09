using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MTG_DeckTester.UserClasses
{
    public class Deck
    {
        List<Card> _cards;
        string _auteur;
        string _nom;

        public Deck(string nom, string auteur)
        {
            string _uriXML = new Uri("decks/" + nom + ".xml", UriKind.Relative).ToString();

            _nom = nom;
            _auteur = auteur;
            
            if (File.Exists(_uriXML))
            {
                DataTable tblDeck = new DataTable(_nom);
                tblDeck.ReadXml(_uriXML);
                _cards = new List<Card>();

                foreach (DataRow dr in tblDeck.Rows)
                {
                    //UserFields.Add(dr["Fiel_Name"].ToString());
                }
            }
            else
            {

            }

        }
    }
}
