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
    /// Logique d'interaction pour GererLesLocation.xaml
    /// </summary>
    public partial class LocationView : Window
    {
        public LocationView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new LocationModifierView();
            MainTitle.Content = "Modifier des Locations";
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frame.Content = new LocationAffichageView();
            MainTitle.Content = "Afficher des Locations";
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            frame.Content = new LocationAjouterView();
            MainTitle.Content = "Ajouter des Locations";
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            frame.Content = new LocationSupprimerView();
            MainTitle.Content = "Supprimer des Locations";
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Close();
        }
    }
}
