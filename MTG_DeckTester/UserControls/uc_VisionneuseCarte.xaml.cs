using MTG_DeckTester.UserClasses;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MTG_DeckTester.UserControls
{
    /// <summary>
    /// Interaction logic for uc_VisionneuseCarte.xaml
    /// </summary>
    public partial class uc_VisionneuseCarte : UserControl
    {
        public Visionneuse Viewer;

        /// <summary>
        /// Constructeur par défaut de la visionneuse
        /// </summary>
        public uc_VisionneuseCarte()
        {
            InitializeComponent();
            Viewer = new Visionneuse();
        }

        /// <summary>
        /// Ajoute une carte passée en paramètre dans la visionneuse
        /// </summary>
        /// <param name="cInstance">Carte à montrer</param>
        public void ShowCard(Card cInstance)
        {
            Viewer = cInstance;
            img_card.Source = new BitmapImage(new Uri(Tools.GetPath(ConfigKeys.CARDS) + CarteVisionnee.ID_Carte +".jpg", UriKind.RelativeOrAbsolute));
            img_card.Visibility = System.Windows.Visibility.Visible;
        }
        
        /// <summary>
        /// Fonction d'écrasement de la visionneuse (à appeler en sortant du MouseOver d'une carte)
        /// </summary>
        public void EraseCard()
        {
            CarteVisionnee = null;
            img_card.Source = null;
            img_card.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
