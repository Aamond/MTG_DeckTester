using MTG_DeckTester.UserClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace MTG_DeckTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Card testcard = new Card("000001.jpg", "Gohei oublié", "Artefact", false);

            //On crée une instance de XmlSerializer dans lequel on lui spécifie le type
            //de l'objet à sérialiser. On utiliser l'opérateur typeof pour cela.
            XmlSerializer serializer = new XmlSerializer(typeof(Card));

            //Création d'un Stream Writer qui permet d'écrire dans un fichier. On lui spécifie le chemin
            //et si le flux devrait mettre le contenu à la suite de notre document (true) ou s'il devrait
            //l'écraser (false).
            StreamWriter _stream = new StreamWriter("C:\\Users\\alex.prost\\Desktop\\CAPTURES\\Test.xml", false);

            //On sérialise en spécifiant le flux d'écriture et l'objet à sérialiser.
            serializer.Serialize(_stream, testcard);

            //IMPORTANT : On ferme le flux en tous temps !!!
            _stream.Close();

            Global.CurrentUser_IP = "127.0.0.1";
            Global.CurrentUser_Name = "Aamond";

            InitializeComponent();
        }
    }
}
