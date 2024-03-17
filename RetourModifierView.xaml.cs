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
    /// Logique d'interaction pour RetourModifierView.xaml
    /// </summary>
    public partial class RetourModifierView : Page
    {
        public ObservableCollection<Retour> Retours { get; set; }
        public RetourModifierView()
        {
            InitializeComponent();

            Retours = RetourViewModel.GetRetour();

            RetourListView.ItemsSource = Retours;
        }

        private void MouseDoubleclick(object sender, MouseButtonEventArgs e)
        {

            Retour selectedDVD = (Retour)RetourListView.SelectedItem;

            if (selectedDVD != null)
            {
                NavigationService.Navigate(new RetourModifierDataView(selectedDVD.RetourId, selectedDVD.LaLocation, selectedDVD.DateReturned));
            }

        }

    }
}
