using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Location_DVD
{
    /// <summary>
    /// Logique d'interaction pour affichage_location.xaml
    /// </summary>
    public partial class LocationSupprimerView : Page
    {
        public ObservableCollection<Location> Locations { get; set; }
        public LocationSupprimerView()
        {
            InitializeComponent();

            // RECUPERE
            Locations = LocationViewModel.GetAllLocation();

            // Ajout des données à la liste view
            LocationListView.ItemsSource = Locations;
        }
        private void DVDListView_MouseDoubleclick(object sender, MouseButtonEventArgs e)
        {
            Location selectedLocation = (Location)LocationListView.SelectedItem;
            if (selectedLocation != null)
            {
                if (MessageBox.Show("Etes vous sur de supprimer la location ?",
                  "Supprimer",
                  MessageBoxButton.YesNo,
                  MessageBoxImage.Question) == MessageBoxResult.Yes)
                {


                    LocationViewModel.DeleteLocation(selectedLocation.LocationId);
                    Locations.Remove(selectedLocation);
                }
            }
        }

    }
}
