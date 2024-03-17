using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
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

    public partial class ClientSupprimerView : Page
    {
        ClientViewModel supprimerModel;
        private readonly ObservableCollection<Client> ClientList;

        public IEnumerable<Location> ListOfLocations { get; private set; }
        public IEnumerable<Location> LocationListView { get; private set; }

        public ClientSupprimerView()
        {
            InitializeComponent();
            supprimerModel = new ClientViewModel();
            ClientList = ClientViewModel.GetAllClients();
            DataContext = supprimerModel;
            ClientListView.ItemsSource = ClientList;
        }
        
        private void ClientListView_MouseDoubleclick(object sender, MouseButtonEventArgs e)
        {
            Client selectedClient = (Client)ClientListView.SelectedItem;

            if (selectedClient != null && ClientList.IndexOf(selectedClient) != 0)
            {
                if (selectedClient.ClientID != 0 && selectedClient.Firstname != null && selectedClient.Lastname != null)
                {
                    if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce client ?",
                        "Supprimer",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        ClientViewModel.DeleteClient(selectedClient.ClientID);
                        ClientList.Remove(selectedClient);
                    }
                }
            }
        }
      
    }
}
