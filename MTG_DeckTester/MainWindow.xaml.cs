using MTG_DeckTester.UserClasses;
using System.Windows;

namespace MTG_DeckTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Global.CurrentUser_IP = "127.0.0.1";
            Global.CurrentUser_Name = "Aamond";

            InitializeComponent();
        }
    }
}
