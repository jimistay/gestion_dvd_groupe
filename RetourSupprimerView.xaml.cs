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
    /// Logique d'interaction pour RetourSupprimerView.xaml
    /// </summary>
    public partial class RetourSupprimerView : Page
    {
        public ObservableCollection<Retour> Retours { get; set; }
        public RetourSupprimerView()
        {
            InitializeComponent();

            Retours = RetourViewModel.GetRetour();

            RetourListView.ItemsSource = Retours;
        }

        private void MouseDoubleclick(object sender, MouseButtonEventArgs e)
        {

            Retour selectedRetour = (Retour)RetourListView.SelectedItem;
            if (selectedRetour != null)
            {
                if (MessageBox.Show("Etes vous sur de supprimer le retour ?",
                  "Supprimer",
                  MessageBoxButton.YesNo,
                  MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    RetourViewModel.DeleteRetour(selectedRetour.RetourId);
                    Retours.Remove(selectedRetour);
                }
            }
        }

    }
}
