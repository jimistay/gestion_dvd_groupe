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
    /// Logique d'interaction pour DVDSupprimerView.xaml
    /// </summary>
    public partial class DVDSupprimerView : Page
    {
        private readonly ObservableCollection<DVD> DVDs;
        public DVDSupprimerView()
        {
            InitializeComponent();

            DVDs = DVDViewModel.GetAllDVDs();

            DVDListView.ItemsSource = DVDs;
        }
        private void DVDListView_MouseDoubleclick(object sender, MouseButtonEventArgs e)
        {
            DVD selectedDVD = (DVD)DVDListView.SelectedItem;

            if(selectedDVD != null)
            {
                if (MessageBox.Show("Etes vous sur de supprimer ce DVD ?",
                  "Supprimer",
                  MessageBoxButton.YesNo,
                  MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                

                    DVDViewModel.DeleteDVD(selectedDVD.DVDId);
                    DVDs.Remove(selectedDVD);
                }
            }
        }
    }
}
