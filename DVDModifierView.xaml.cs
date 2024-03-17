using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace Location_DVD
{
    public partial class DVDModifierView : Page
    {
        public ObservableCollection<DVD> DVDs { get; set; }
        public DVDModifierView()
        {
            InitializeComponent();

            DVDs = DVDViewModel.GetAllDVDs();

            DVDListView.ItemsSource = DVDs;
        }

        private void DVDListView_MouseDoubleclick(object sender, MouseButtonEventArgs e)
        {
 
               DVD selectedDVD = (DVD)DVDListView.SelectedItem;

                if (selectedDVD != null)
                {
                    NavigationService.Navigate(new DVDModifiePage2View(selectedDVD.DVDId, selectedDVD.Title, selectedDVD.Director, selectedDVD.Genre, selectedDVD.ReleaseYear, selectedDVD.IsAvailable));
                }
     
        }
    }
}