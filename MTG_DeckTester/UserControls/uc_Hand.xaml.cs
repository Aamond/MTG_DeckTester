using MTG_DeckTester.UserClasses;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MTG_DeckTester.UserControls
{
    public partial class uc_Hand : UserControl
    {
        public List<Card> Main;

        public uc_Hand()
        {
            int CptCartes;
            string NomImage;

            Main = new List<Card>();
            InitializeComponent();

            if (Main.Count < 9)
            {
                for (CptCartes = 0; CptCartes < Main.Count; CptCartes++)
                {
                    NomImage = "img_card_" + CptCartes;
                }
            }
            else
            {

            }
            

        }
    }
}
