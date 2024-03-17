using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Location_DVD
{
    /// <summary>
    /// Logique d'interaction pour DVDView.xaml
    /// </summary>
    public partial class DVDView : Window
    {
        public DVDView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new DVDAffichageView();
            MainTitle.Content = "Liste des DVD";

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new DVDAjouterView();
            MainTitle.Content = "Ajouter un DVD";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Main.Content = new DVDModifierView();
            MainTitle.Content = "Modifier un DVD";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Main.Content = new DVDSupprimerView();
            MainTitle.Content = "Supprimer un DVD";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Close();
        }
    }
}
