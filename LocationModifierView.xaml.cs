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
    /// Logique d'interaction pour edit_location.xaml
    /// </summary>
    public partial class LocationModifierView : Page
    {
        public ObservableCollection<Location> Locations { get; set; }
        public LocationModifierView()
        {
            InitializeComponent();
            Locations = LocationViewModel.GetAllLocation();
            LocationListView.ItemsSource = Locations;
        }
        private void DVDListView_MouseDoubleclick(object sender, MouseButtonEventArgs e)
        {

            Location selectedDVD = (Location)LocationListView.SelectedItem;

            if (selectedDVD != null)
            {
                //NavigationService.Navigate(new DVDModifiePage2View(selectedDVD.DVDId, selectedDVD.Title, selectedDVD.Director, selectedDVD.Genre, selectedDVD.ReleaseYear, selectedDVD.IsAvailable));
                NavigationService.Navigate(new LocationModifierDataView(selectedDVD.LocationId, selectedDVD.LeClient, selectedDVD.LeDVD, selectedDVD.DateReturned, selectedDVD.DateRented));
            }

        }
    }
}
